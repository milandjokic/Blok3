using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PerLengthSequenceImpedance : PerLengthImpedance
    {
        public float B0ch { get; set; }
        public float Bch { get; set; }
        public float G0ch { get; set; }
        public float Gch { get; set; }
        public float R { get; set; }
        public float R0 { get; set; }
        public float X { get; set; }
        public float X0 { get; set; }

        public PerLengthSequenceImpedance(long globalId) : base(globalId) { }
    }
}
