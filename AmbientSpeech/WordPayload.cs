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
    }
}
