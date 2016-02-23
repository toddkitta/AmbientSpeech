using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientSpeech
{
    public class KinectPresenceDetector : IPresenceDetector
    {
        private KinectSensor sensor = null;
        private BodyFrameReader bodyFrameReader = null;
        DateTime? lastBodySeen = null;
        private Body[] bodies = null;

        public int PresenceTimeoutSeconds { get; set; } = 2;

        private int? SecondsSinceBodiesSeen
        {
            get
            {
                if (lastBodySeen == null)
                    return null;

                return (DateTime.Now - lastBodySeen.Value).Seconds;
            }
        }

        public event EventHandler PresenceDetected;
        public event EventHandler PresenceTimeout;

        public KinectPresenceDetector()
        {
            sensor = KinectSensor.GetDefault();
        }

        public void StartWatching()
        {
            if (sensor == null)// || !sensor.IsAvailable)
                throw new InvalidOperationException("Kinect Sensor is null or not available.");

            bodyFrameReader = sensor.BodyFrameSource.OpenReader();
            bodyFrameReader.FrameArrived += BodyFrameReader_FrameArrived;
            sensor.Open();
        }

        public void StopWatching()
        {
            bodyFrameReader.FrameArrived -= BodyFrameReader_FrameArrived;
            bodyFrameReader.Dispose();
            bodyFrameReader = null;

            sensor.Close();
        }

        private void BodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool bodiesPresent = false;
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null && bodyFrame.BodyCount > 0)
                {
                    if (bodies == null)
                        bodies = new Body[bodyFrame.BodyCount];

                    bodyFrame.GetAndRefreshBodyData(bodies);

                    bodiesPresent = (from b in bodies
                                     where b != null && b.IsTracked
                                     select b).FirstOrDefault() != null;
                }

                if (bodiesPresent)
                {
                    bool raiseEvent = !lastBodySeen.HasValue;
                    lastBodySeen = DateTime.Now;

                    if (raiseEvent)
                        OnPresenceDetected(EventArgs.Empty);
                }
                else
                {
                    if (SecondsSinceBodiesSeen.HasValue && SecondsSinceBodiesSeen.Value >= PresenceTimeoutSeconds)
                    {
                        lastBodySeen = null;
                        OnPresenceTimeout(EventArgs.Empty);
                    }
                }
            }
        }

        protected virtual void OnPresenceDetected(EventArgs e)
        {
            EventHandler handler = PresenceDetected;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnPresenceTimeout(EventArgs e)
        {
            EventHandler handler = PresenceTimeout;
            if (handler != null)
                handler(this, e);
        }
    }
}
