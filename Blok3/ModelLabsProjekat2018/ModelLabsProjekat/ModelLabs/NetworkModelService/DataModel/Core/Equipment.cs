using FTN.Common;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
	public class Equipment : PowerSystemResource
	{
		public long EquipmentContainer { get; set; } = 0;

		public Equipment(long globalId) : base(globalId) { }

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region IAccess implementation

		public override bool HasProperty(ModelCode property)
		{
			return base.HasProperty(property);
		}

		public override void GetProperty(Property property)
		{
			base.GetProperty(property);
		}

		public override void SetProperty(Property property)
		{
			base.SetProperty(property);
		}

		#endregion IAccess implementation

		#region IReference implementation

		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (EquipmentContainer != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.EQUIPMENT_EQUIPCONT] = new List<long>();
				references[ModelCode.EQUIPMENT_EQUIPCONT].Add(EquipmentContainer);
			}

			base.GetReferences(references, refType);
		}

		#endregion IReference implementation
	}
}
