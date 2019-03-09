namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				
			}
		}

		public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
			}
		}

		public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);
			}
		}

		public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConductingEquipment != null) && (rd != null))
			{
				PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);
			}
		}

		public static void PopulateSeriesCompensatorProperties(FTN.SeriesCompensator cimSerComp, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimSerComp != null) && (rd != null))
			{
				PopulateConductingEquipmentProperties(cimSerComp, rd, importHelper, report);

				if (cimSerComp.RHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERCOMP_R, cimSerComp.R));
				}

				if (cimSerComp.R0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERCOMP_R0, cimSerComp.R0));
				}

				if (cimSerComp.XHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERCOMP_X, cimSerComp.X));
				}
				
				if (cimSerComp.X0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERCOMP_X0, cimSerComp.X0));
				}
			}
		}

		public static void PopulateConductorProperties(FTN.Conductor cimConductor, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConductor != null) && (rd != null))
			{
				PopulateConductingEquipmentProperties(cimConductor, rd, importHelper, report);

				if (cimConductor.LengthHasValue)
				{
					rd.AddProperty(new Property(ModelCode.CONDUCTOR_LENGTH, cimConductor.Length));
				}
			}
		}

		public static void PopulateDCLineSegmentProperties(FTN.DCLineSegment cimDCLineSeg, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimDCLineSeg != null) && (rd != null))
			{
				PopulateConductorProperties(cimDCLineSeg, rd, importHelper, report);
			}
		}

		public static void PopulateACLineSegmentProperties(FTN.ACLineSegment cimACLineSeg, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimACLineSeg != null) && (rd != null))
			{
				PopulateConductorProperties(cimACLineSeg, rd, importHelper, report);

				if (cimACLineSeg.B0chHasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_B0CH, cimACLineSeg.B0ch));
				}

				if (cimACLineSeg.BchHasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_BCH, cimACLineSeg.Bch));
				}

				if (cimACLineSeg.G0chHasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_G0CH, cimACLineSeg.G0ch));
				}

				if (cimACLineSeg.GchHasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_GCH, cimACLineSeg.Gch));
				}

				if (cimACLineSeg.RHasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_R, cimACLineSeg.R));
				}

				if (cimACLineSeg.R0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_R0, cimACLineSeg.R0));
				}

				if (cimACLineSeg.XHasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_X, cimACLineSeg.X));
				}

				if (cimACLineSeg.X0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.ACLINESEG_X0, cimACLineSeg.X0));
				}
			}
		}

		public static void PopulateConnectivityNodeContainerProperties(FTN.ConnectivityNodeContainer cimConNodeCont, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConNodeCont != null) && (rd != null))
			{
				PopulatePowerSystemResourceProperties(cimConNodeCont, rd, importHelper, report);
			}
		}

		public static void PopulateEquipmentContainerProperties(FTN.EquipmentContainer cimEquipCont, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipCont != null) && (rd != null))
			{
				PopulateConnectivityNodeContainerProperties(cimEquipCont, rd, importHelper, report);
			}
		}

		public static void PopulateLineProperties(FTN.Line cimLine, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimLine != null) && (rd != null))
			{
				PopulateEquipmentContainerProperties(cimLine, rd, importHelper, report);
			}
		}

		public static void PopulateSubGeographicalRegionProperties(FTN.SubGeographicalRegion cimSubGeoReg, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimSubGeoReg != null) && (rd != null))
			{
				PopulateIdentifiedObjectProperties(cimSubGeoReg, rd);
			}

		}

		public static void PopulatePerLengthImpedanceProperties(FTN.PerLengthImpedance cimPerLenImp, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPerLenImp != null) && (rd != null))
			{
				PopulateIdentifiedObjectProperties(cimPerLenImp, rd);
			}
		}

		public static void PopulatePerLengthSequenceImpedanceProperties(FTN.PerLengthSequenceImpedance cimPerLenSeqImp, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPerLenSeqImp != null) && (rd != null))
			{
				PopulatePerLengthImpedanceProperties(cimPerLenSeqImp, rd, importHelper, report);

				if (cimPerLenSeqImp.B0chHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_B0CH, cimPerLenSeqImp.B0ch));
				}

				if (cimPerLenSeqImp.BchHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_BCH, cimPerLenSeqImp.Bch));
				}

				if (cimPerLenSeqImp.G0chHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_G0CH, cimPerLenSeqImp.G0ch));
				}

				if (cimPerLenSeqImp.GchHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_GCH, cimPerLenSeqImp.Gch));
				}

				if (cimPerLenSeqImp.RHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_R, cimPerLenSeqImp.R));
				}

				if (cimPerLenSeqImp.R0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_R0, cimPerLenSeqImp.R0));
				}

				if (cimPerLenSeqImp.XHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_X, cimPerLenSeqImp.X));
				}

				if (cimPerLenSeqImp.X0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.PERLENSEQIMP_X0, cimPerLenSeqImp.X0));
				}
			}
		}
		
		#endregion Populate ResourceDescription

		#region Enums convert

		#endregion Enums convert
	}
}
