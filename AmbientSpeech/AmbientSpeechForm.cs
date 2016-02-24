using Microsoft.ProjectOxford.SpeechRecognition;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace AmbientSpeech
{
    public partial class AmbientSpeechForm : Form
    {
        private const string LANGUAGE = "en-us";

        private string oxfordKey;
        private string deviceLocation;
        private string deviceName;
        private MicrophoneRecognitionClient micClient;
        private IPresenceDetector presenceDetector;
        private EventHubClient<WordPayload> eventHubClient;

        private delegate void WriteTextBoxLineCallback(TextBox textBox, string text);
        private delegate void ClearTextBoxCallback(TextBox textBox);
        private delegate void SetMicImageCallback(bool on);

        public AmbientSpeechForm()
        {
            InitializeComponent();
        }

        private void AmbientSpeechForm_Load(object sender, EventArgs e)
        {
            oxfordKey = ConfigurationManager.AppSettings["OxfordKey"];
            deviceLocation = ConfigurationManager.AppSettings["Location"];
            deviceName = ConfigurationManager.AppSettings["DeviceName"];

            eventHubClient = new EventHubClient<WordPayload>(
                ConfigurationManager.AppSettings["EventHubTokenApiEndpoint"],
                ConfigurationManager.AppSettings["ServiceBusNamespace"],
                ConfigurationManager.AppSettings["EventHub"],
                ConfigurationManager.AppSettings["EventHubPolicyName"],
                ConfigurationManager.AppSettings["DeviceId"]);

            InitMicClient(false);
            InitKinectPresenceDetector();
        }

        private void InitKinectPresenceDetector()
        {
            if (presenceDetector != null)
            {
                presenceDetector.StopWatching();
            }

            presenceDetector = new KinectPresenceDetector();
            presenceDetector.PresenceTimeoutSeconds = 1;
            presenceDetector.PresenceDetected += PresenceDetector_PresenceDetected;
            presenceDetector.PresenceTimeout += PresenceDetector_PresenceTimeout;

            presenceDetector.StartWatching();
        }

        private void InitMicClient(bool startListening)
        {
            DestroyMicClient();

            micClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                SpeechRecognitionMode.LongDictation,
                LANGUAGE,
                oxfordKey);

            micClient.OnMicrophoneStatus += OnMicrophoneStatus;
            micClient.OnPartialResponseReceived += OnPartialResponseReceivedHandler;
            micClient.OnResponseReceived += OnMicDictationResponseReceivedHandler;
            micClient.OnConversationError += OnConversationErrorHandler;

            if (startListening)
                micClient.StartMicAndRecognition();
        }

        private void DestroyMicClient()
        {
            if (micClient != null)
            {
                //micClient.EndMicAndRecognition();
                micClient.Dispose();
                micClient = null;
            }
        }

        private void WriteTextBoxLine(TextBox txt, string message)
        {
            if (txt.InvokeRequired)
            {
                WriteTextBoxLineCallback d = new WriteTextBoxLineCallback(WriteTextBoxLine);
                Invoke(d, new object[] { txt, message });
            }
            else
            {
                if (!txt.IsDisposed)
                {
                    txt.AppendText(message);
                    txt.AppendText(Environment.NewLine);
                }
            }
        }

        private void ClearTextBox(TextBox txt)
        {
            if (txt.InvokeRequired)
            {
                ClearTextBoxCallback d = new ClearTextBoxCallback(ClearTextBox);
                Invoke(d, new object[] { txt });
            }
            else
            {
                txt.Clear();
            }
        }

        private void SetMicImage(bool on)
        {
            if (listeningIndicator.InvokeRequired)
            {
                SetMicImageCallback d = new SetMicImageCallback(SetMicImage);
                Invoke(d, new object[] { on });
            }
            else
            {
                string fileName = String.Format("Resources\\{0}.png", on ? "micon" : "micoff");
                listeningIndicator.Image = Image.FromFile(fileName);
            }
        }

        private void PresenceDetector_PresenceTimeout(object sender, EventArgs e)
        {
            DestroyMicClient();
            SetMicImage(false);
            WriteTextBoxLine(txtPartial, "NOT LISTENING...");
        }

        private void PresenceDetector_PresenceDetected(object sender, EventArgs e)
        {
            if (micClient == null)
                InitMicClient(false);

            micClient.StartMicAndRecognition();
            SetMicImage(true);
        }

        #region Mic Event Handlers

        private void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
        {
            ClearTextBox(txtFinal);

            WriteTextBoxLine(txtFinal, String.Format("ERROR CODE: {0}", e.SpeechErrorCode.ToString()));
            WriteTextBoxLine(txtFinal, String.Format("ERROR TEXT: {0}", e.SpeechErrorText));
            WriteTextBoxLine(txtFinal, String.Empty);

            InitMicClient(true);
        }

        private void OnMicDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            ClearTextBox(txtFinal);

            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout)
            {
                micClient.EndMicAndRecognition();
            }

            if (e.PhraseResponse.Results.Length == 0)
            {
                WriteTextBoxLine(txtFinal, "NOTHING RETURNED");
            }
            else
            {
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    WriteTextBoxLine(txtFinal,
                        String.Format("[{0}]: \"{2}\" (Confidence = {1})",
                            i,
                            e.PhraseResponse.Results[i].Confidence,
                            e.PhraseResponse.Results[i].DisplayText));
                }
                WriteTextBoxLine(txtFinal, String.Empty);

                DateTime dtm = DateTime.Now;


                // send results here
                foreach (var w in e.PhraseResponse.Results[0].DisplayText.GetCleansedWords())
                {
                    eventHubClient.PostPayload(new WordPayload() { Word = w, WordTime = dtm, DeviceName = deviceName, Location = deviceLocation });
                    WriteTextBoxLine(wordOutput, w);
                }
            }

            InitMicClient(true);
        }

        private void OnPartialResponseReceivedHandler(object sender, PartialSpeechResponseEventArgs e)
        {
            WriteTextBoxLine(txtPartial, e.PartialResult);
        }

        private void OnMicrophoneStatus(object sender, MicrophoneEventArgs e)
        {
            WriteTextBoxLine(txtPartial, e.Recording ? "LISTENING..." : "NOT LISTENING (for some reason...)");
            WriteTextBoxLine(txtPartial, String.Empty);
        }

        #endregion

        private void AmbientSpeechForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            presenceDetector.StopWatching();
            DestroyMicClient();
        }

        private void alwaysListen_CheckedChanged(object sender, EventArgs e)
        {
            if (alwaysListen.Checked)
            {
                presenceDetector.StopWatching();
                InitMicClient(true);
                SetMicImage(true);
            }
            else
            {
                SetMicImage(false);
                WriteTextBoxLine(txtPartial, "NOT LISTENING...");
                DestroyMicClient();
                InitKinectPresenceDetector();
            }
        }
    }
}
