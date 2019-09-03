using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class ACLineSegment : Conductor
    {
        public float B0ch { get; set; }
        public float Bch { get; set; }
        public float G0ch { get; set; }
        public float Gch { get; set; }
        public float R { get; set; }
        public float R0 { get; set; }
        public float X { get; set; }
        public float X0 { get; set; }

        public long PerLengthImpedance { get; set; } = 0;

        public ACLineSegment(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ACLineSegment x = (ACLineSegment)obj;
                return ((x.B0ch == B0ch) && (x.Bch == Bch) && (x.G0ch == G0ch) && (x.Gch == Gch) && (x.R == R) && (x.R0 == R0) && 
                    (x.X == X) && (x.X0 == X0) && (x.PerLengthImpedance == PerLengthImpedance));
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
                case ModelCode.ACLINESEG_B0CH:
                case ModelCode.ACLINESEG_BCH:
                case ModelCode.ACLINESEG_G0CH:
                case ModelCode.ACLINESEG_GCH:
                case ModelCode.ACLINESEG_R:
                case ModelCode.ACLINESEG_R0:
                case ModelCode.ACLINESEG_X:
                case ModelCode.ACLINESEG_X0:
                case ModelCode.ACLINESEG_PERLENIMP:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.ACLINESEG_B0CH:
                    property.SetValue(B0ch);
                    break;
                case ModelCode.ACLINESEG_BCH:
                    property.SetValue(Bch);
                    break;
                case ModelCode.ACLINESEG_G0CH:
                    property.SetValue(G0ch);
                    break;
                case ModelCode.ACLINESEG_GCH:
                    property.SetValue(Gch);
                    break;
                case ModelCode.ACLINESEG_R:
                    property.SetValue(R);
                    break;
                case ModelCode.ACLINESEG_R0:
                    property.SetValue(R0);
                    break;
                case ModelCode.ACLINESEG_X:
                    property.SetValue(X);
                    break;
                case ModelCode.ACLINESEG_X0:
                    property.SetValue(X0);
                    break;
                case ModelCode.ACLINESEG_PERLENIMP:
                    property.SetValue(PerLengthImpedance);
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
                case ModelCode.ACLINESEG_B0CH:
                    B0ch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_BCH:
                    Bch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_G0CH:
                    G0ch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_GCH:
                    Gch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_R:
                    R = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_R0:
                    R0 = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_X:
                    X = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_X0:
                    X0 = property.AsFloat();
                    break;
                case ModelCode.ACLINESEG_PERLENIMP:
                    PerLengthImpedance = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (PerLengthImpedance != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.ACLINESEG_PERLENIMP] = new List<long>();
                references[ModelCode.ACLINESEG_PERLENIMP].Add(PerLengthImpedance);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
