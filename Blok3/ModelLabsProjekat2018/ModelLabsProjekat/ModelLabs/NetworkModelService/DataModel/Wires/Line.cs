using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Line : EquipmentContainer
    {
        public Line(long globalId) : base(globalId) { }

        #region IReference implementation

        //public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        //{
        //    if (baseVoltage != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
        //    {
        //        references[ModelCode.CONDEQ_BASVOLTAGE] = new List<long>();
        //        references[ModelCode.CONDEQ_BASVOLTAGE].Add(baseVoltage);
        //    }

        //    base.GetReferences(references, refType);

        //    // Ovde treba dodati reference
        //}

        #endregion IReference implementation
    }
}
