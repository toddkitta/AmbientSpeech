using Microsoft.ProjectOxford.SpeechRecognition;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace AmbientSpeech
{
    public partial class AmbientSpeechForm : Form
    {
        private delegate void WriteTextBoxLineCallback(TextBox textBox, string text);
        private delegate void ClearTextBoxCallback(TextBox textBox);

        private MicrophoneRecognitionClient micClient;
        private string oxfordKey;

        private const string LANGUAGE = "en-us";

        public AmbientSpeechForm()
        {
            InitializeComponent();
        }

        private void AmbientSpeechForm_Load(object sender, EventArgs e)
        {
            oxfordKey = ConfigurationManager.AppSettings["OxfordKey"];
            InitMicClient();
        }

        private void InitMicClient()
        {
            if(micClient != null)
            {
                micClient.Dispose();
                micClient = null;
            }

            micClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                SpeechRecognitionMode.LongDictation,
                LANGUAGE,
                oxfordKey);

            micClient.OnMicrophoneStatus += OnMicrophoneStatus;
            micClient.OnPartialResponseReceived += OnPartialResponseReceivedHandler;
            micClient.OnResponseReceived += OnMicDictationResponseReceivedHandler;
            micClient.OnConversationError += OnConversationErrorHandler;

            micClient.StartMicAndRecognition();
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

        #region Event Handlers

        private void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
        {
            ClearTextBox(txtFinal);

            WriteTextBoxLine(txtFinal, String.Format("ERROR CODE: {0}", e.SpeechErrorCode.ToString()));
            WriteTextBoxLine(txtFinal, String.Format("ERROR TEXT: {0}", e.SpeechErrorText));
            WriteTextBoxLine(txtFinal, String.Empty);

            InitMicClient();
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
            }

            InitMicClient();
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
    }
}
