using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientSpeech
{
    public class AlwaysOnPresenceDetector : IPresenceDetector
    {
        public int PresenceTimeoutSeconds { get; set; }

        public event EventHandler PresenceDetected;
        public event EventHandler PresenceTimeout;

        public void StartWatching()
        {
            OnPresenceDetected(EventArgs.Empty);
        }

        public void StopWatching()
        {
        }

        protected virtual void OnPresenceDetected(EventArgs e)
        {
            EventHandler handler = PresenceDetected;
            if (handler != null)
                handler(this, e);
        }
    }
}
