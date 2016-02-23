using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientSpeech
{
    public interface IPresenceDetector
    {
        int PresenceTimeoutSeconds { get; set; }
        event EventHandler PresenceDetected;
        event EventHandler PresenceTimeout;
        void StartWatching();
        void StopWatching();
    }
}
