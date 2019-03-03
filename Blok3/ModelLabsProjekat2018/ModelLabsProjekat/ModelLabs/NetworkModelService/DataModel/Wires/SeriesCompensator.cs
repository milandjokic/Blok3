using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class SeriesCompensator : ConductingEquipment
    {
        public float R { get; set; }
        public float R0 { get; set; }
        public float X { get; set; }
        public float X0 { get; set; }

        public SeriesCompensator(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SeriesCompensator x = (SeriesCompensator)obj;
                return ( (x.R == R) && (x.R0 == R0) && (x.X == X) && (x.X0 == X0) );
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
                case ModelCode.SERCOMP_R:
                case ModelCode.SERCOMP_R0:
                case ModelCode.SERCOMP_X:
                case ModelCode.SERCOMP_X0:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SERCOMP_R:
                    property.SetValue(R);
                    break;
                case ModelCode.SERCOMP_R0:
                    property.SetValue(R0);
                    break;
                case ModelCode.SERCOMP_X:
                    property.SetValue(X);
                    break;
                case ModelCode.SERCOMP_X0:
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
                case ModelCode.SERCOMP_R:
                    R = property.AsFloat();
                    break;
                case ModelCode.SERCOMP_R0:
                    R0 = property.AsFloat();
                    break;
                case ModelCode.SERCOMP_X:
                    X = property.AsFloat();
                    break;
                case ModelCode.SERCOMP_X0:
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
