using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Line : EquipmentContainer
    {
        public long SubGeographicalRegion { get; set; } = 0;

        public Line(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Line x = (Line)obj;
                return (x.SubGeographicalRegion == SubGeographicalRegion);
            }

            return false;
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
                case ModelCode.LINE_SUBGEOREG:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.LINE_SUBGEOREG:
                    property.SetValue(SubGeographicalRegion);
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
                case ModelCode.LINE_SUBGEOREG:
                    SubGeographicalRegion = property.AsReference();
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
            if (SubGeographicalRegion != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.LINE_SUBGEOREG] = new List<long>();
                references[ModelCode.LINE_SUBGEOREG].Add(SubGeographicalRegion);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
