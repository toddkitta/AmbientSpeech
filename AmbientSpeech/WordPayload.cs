using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientSpeech
{
    public struct WordPayload
    {
        public DateTime WordTime { get; set; }
        public string Word { get; set; }
        public string Location { get; set; }
        public string DeviceName { get; set; }
    }
}
