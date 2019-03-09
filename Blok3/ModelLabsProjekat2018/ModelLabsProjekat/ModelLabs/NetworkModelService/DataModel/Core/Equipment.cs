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
			if (base.Equals(obj))
			{
				Equipment x = (Equipment)obj;
				return (x.EquipmentContainer == EquipmentContainer);
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
				case ModelCode.EQUIPMENT_EQUIPCONT:
					return true;

				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.EQUIPMENT_EQUIPCONT:
					property.SetValue(EquipmentContainer);
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
				case ModelCode.EQUIPMENT_EQUIPCONT:
					EquipmentContainer = property.AsReference();
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
