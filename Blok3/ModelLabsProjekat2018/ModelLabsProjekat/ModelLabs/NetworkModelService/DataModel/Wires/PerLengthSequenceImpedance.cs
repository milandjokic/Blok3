using FTN.Common;

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

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PerLengthSequenceImpedance x = (PerLengthSequenceImpedance)obj;
                return ( (x.B0ch == B0ch) && (x.Bch == Bch) && (x.G0ch == G0ch) && (x.Gch == Gch) && (x.R == R) && (x.R0 == R0) && (x.X == X) && (x.X0 == X0) );
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.PERLENSEQIMP_B0CH:
                case ModelCode.PERLENSEQIMP_BCH:
                case ModelCode.PERLENSEQIMP_G0CH:
                case ModelCode.PERLENSEQIMP_GCH:
                case ModelCode.PERLENSEQIMP_R:
                case ModelCode.PERLENSEQIMP_R0:
                case ModelCode.PERLENSEQIMP_X:
                case ModelCode.PERLENSEQIMP_X0:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.PERLENSEQIMP_B0CH:
                    property.SetValue(B0ch);
                    break;
                case ModelCode.PERLENSEQIMP_BCH:
                    property.SetValue(Bch);
                    break;
                case ModelCode.PERLENSEQIMP_G0CH:
                    property.SetValue(G0ch);
                    break;
                case ModelCode.PERLENSEQIMP_GCH:
                    property.SetValue(Gch);
                    break;
                case ModelCode.PERLENSEQIMP_R:
                    property.SetValue(R);
                    break;
                case ModelCode.PERLENSEQIMP_R0:
                    property.SetValue(R0);
                    break;
                case ModelCode.PERLENSEQIMP_X:
                    property.SetValue(X);
                    break;
                case ModelCode.PERLENSEQIMP_X0:
                    property.SetValue(X0);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.PERLENSEQIMP_B0CH:
                    B0ch = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_BCH:
                    Bch = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_G0CH:
                    G0ch = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_GCH:
                    Gch = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_R:
                    R = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_R0:
                    R0 = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_X:
                    X = property.AsFloat();
                    break;
                case ModelCode.PERLENSEQIMP_X0:
                    X0 = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
    }
}
