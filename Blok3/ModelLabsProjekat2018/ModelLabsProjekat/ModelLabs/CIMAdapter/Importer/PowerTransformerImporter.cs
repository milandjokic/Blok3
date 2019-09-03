using CIM.Model;
using FTN.Common;
using FTN.ESI.SIMES.CIM.CIMAdapter.Manager;
using System;
using System.Collections.Generic;

namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	/// <summary>
	/// PowerTransformerImporter
	/// </summary>
	public class PowerTransformerImporter // TODO
	{
		/// <summary> Singleton </summary>
		private static PowerTransformerImporter ptImporter = null;
		private static object singletoneLock = new object();

		private ConcreteModel concreteModel;
		private Delta delta;
		private ImportHelper importHelper;
		private TransformAndLoadReport report;


		#region Properties
		public static PowerTransformerImporter Instance
		{
			get
			{
				if (ptImporter == null)
				{
					lock (singletoneLock)
					{
						if (ptImporter == null)
						{
							ptImporter = new PowerTransformerImporter();
							ptImporter.Reset();
						}
					}
				}
				return ptImporter;
			}
		}

		public Delta NMSDelta
		{
			get 
			{
				return delta;
			}
		}
		#endregion Properties


		public void Reset()
		{
			concreteModel = null;
			delta = new Delta();
			importHelper = new ImportHelper();
			report = null;
		}

		public TransformAndLoadReport CreateNMSDelta(ConcreteModel cimConcreteModel)
		{
			LogManager.Log("Importing PowerTransformer Elements...", LogLevel.Info);
			report = new TransformAndLoadReport();
			concreteModel = cimConcreteModel;
			delta.ClearDeltaOperations();

			if ((concreteModel != null) && (concreteModel.ModelMap != null))
			{
				try
				{
					// convert into DMS elements
					ConvertModelAndPopulateDelta();
				}
				catch (Exception ex)
				{
					string message = string.Format("{0} - ERROR in data import - {1}", DateTime.Now, ex.Message);
					LogManager.Log(message);
					report.Report.AppendLine(ex.Message);
					report.Success = false;
				}
			}
			LogManager.Log("Importing PowerTransformer Elements - END.", LogLevel.Info);
			return report;
		}

		/// <summary>
		/// Method performs conversion of network elements from CIM based concrete model into DMS model.
		/// </summary>
		private void ConvertModelAndPopulateDelta()
		{
			LogManager.Log("Loading elements and creating delta...", LogLevel.Info);

			//// import all concrete model types (DMSType enum)
			ImportSubGeographicalRegions();
            ImportPerLengthSequenceImpedances();
			ImportLines();
			ImportDCLineSegments();
			ImportACLineSegments();
			ImportSeriesCompensators();


            LogManager.Log("Loading elements and creating delta completed.", LogLevel.Info);
		}

		#region Import

		#region PerLengthSequenceImpedance

		private void ImportPerLengthSequenceImpedances()
		{
			SortedDictionary<string, object> cimPerLenSeqImps = concreteModel.GetAllObjectsOfType("FTN.PerLengthSequenceImpedance");
			if (cimPerLenSeqImps != null)
			{
				foreach (KeyValuePair<string, object> cimPerLenSeqImpPair in cimPerLenSeqImps)
				{
					FTN.PerLengthSequenceImpedance cimPerLenSeqImp = cimPerLenSeqImpPair.Value as FTN.PerLengthSequenceImpedance;
					
					ResourceDescription rd = CreatePerLengthSequenceImpedanceResourceDescription(cimPerLenSeqImp);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("PerLengthSequenceImpedance ID = ").Append(cimPerLenSeqImp.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("PerLengthSequenceImpedance ID = ").Append(cimPerLenSeqImp.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreatePerLengthSequenceImpedanceResourceDescription(FTN.PerLengthSequenceImpedance cimPerLenSeqImp)
		{
			ResourceDescription rd = null;
			if (cimPerLenSeqImp != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.PERLENSEQIMP, importHelper.CheckOutIndexForDMSType(DMSType.PERLENSEQIMP));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimPerLenSeqImp.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulatePerLengthSequenceImpedanceProperties(cimPerLenSeqImp, rd, importHelper, report);
			}
			return rd;
		}

		#endregion PerLengthSequenceImpedance

		#region SubGeographicalRegion

		private void ImportSubGeographicalRegions()
		{
			SortedDictionary<string, object> cimSubGeoRegs = concreteModel.GetAllObjectsOfType("FTN.SubGeographicalRegion");
			if (cimSubGeoRegs != null)
			{
				foreach (KeyValuePair<string, object> cimSubGeoRegPair in cimSubGeoRegs)
				{
					FTN.SubGeographicalRegion cimSubGeoReg = cimSubGeoRegPair.Value as FTN.SubGeographicalRegion;

					ResourceDescription rd = CreateSubGeographicalRegionResourceDescription(cimSubGeoReg);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("SubGeographicalRegion ID = ").Append(cimSubGeoReg.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("SubGeographicalRegion ID = ").Append(cimSubGeoReg.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateSubGeographicalRegionResourceDescription(FTN.SubGeographicalRegion cimSubGeoReg)
		{
			ResourceDescription rd = null;
			if (cimSubGeoReg != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.SUBGEOREG, importHelper.CheckOutIndexForDMSType(DMSType.SUBGEOREG));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimSubGeoReg.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateSubGeographicalRegionProperties(cimSubGeoReg, rd, importHelper, report);
			}
			return rd;
		}

		#endregion PerLengthSequenceImpedance

		#region SeriesCompensator

		private void ImportSeriesCompensators()
		{
			SortedDictionary<string, object> cimSerComps = concreteModel.GetAllObjectsOfType("FTN.SeriesCompensator");
			if (cimSerComps != null)
			{
				foreach (KeyValuePair<string, object> cimSerCompPair in cimSerComps)
				{
					FTN.SeriesCompensator cimSerComp = cimSerCompPair.Value as FTN.SeriesCompensator;

					ResourceDescription rd = CreateSeriesCompensatorResourceDescription(cimSerComp);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("SeriesCompensator ID = ").Append(cimSerComp.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("SeriesCompensator ID = ").Append(cimSerComp.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateSeriesCompensatorResourceDescription(FTN.SeriesCompensator cimSerComp)
		{
			ResourceDescription rd = null;
			if (cimSerComp != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.SERCOMP, importHelper.CheckOutIndexForDMSType(DMSType.SERCOMP));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimSerComp.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateSeriesCompensatorProperties(cimSerComp, rd, importHelper, report);
			}
			return rd;
		}

		#endregion SeriesCompensator

		#region DCLineSegment

		private void ImportDCLineSegments()
		{
			SortedDictionary<string, object> cimDCLineSegments = concreteModel.GetAllObjectsOfType("FTN.DCLineSegment");
			if (cimDCLineSegments != null)
			{
				foreach (KeyValuePair<string, object> cimDCLineSegPair in cimDCLineSegments)
				{
					FTN.DCLineSegment cimDCLineSeg = cimDCLineSegPair.Value as FTN.DCLineSegment;

					ResourceDescription rd = CreateDCLineSegmentResourceDescription(cimDCLineSeg);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("DCLineSegment ID = ").Append(cimDCLineSeg.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("DCLineSegment ID = ").Append(cimDCLineSeg.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateDCLineSegmentResourceDescription(FTN.DCLineSegment cimDCLineSeg)
		{
			ResourceDescription rd = null;
			if (cimDCLineSeg != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.DCLINESEG, importHelper.CheckOutIndexForDMSType(DMSType.DCLINESEG));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimDCLineSeg.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateDCLineSegmentProperties(cimDCLineSeg, rd, importHelper, report);
			}
			return rd;
		}

		#endregion DCLineSegment

		#region ACLineSegment

		private void ImportACLineSegments()
		{
			SortedDictionary<string, object> cimACLineSegments = concreteModel.GetAllObjectsOfType("FTN.ACLineSegment");
			if (cimACLineSegments != null)
			{
				foreach (KeyValuePair<string, object> cimACLineSegPair in cimACLineSegments)
				{
					FTN.ACLineSegment cimACLineSeg = cimACLineSegPair.Value as FTN.ACLineSegment;

					ResourceDescription rd = CreateACLineSegmentResourceDescription(cimACLineSeg);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("ACLineSegment ID = ").Append(cimACLineSeg.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("ACLineSegment ID = ").Append(cimACLineSeg.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateACLineSegmentResourceDescription(FTN.ACLineSegment cimACLineSeg)
		{
			ResourceDescription rd = null;
			if (cimACLineSeg != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.ACLINESEG, importHelper.CheckOutIndexForDMSType(DMSType.ACLINESEG));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimACLineSeg.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateACLineSegmentProperties(cimACLineSeg, rd, importHelper, report);
			}
			return rd;
		}

		#endregion ACLineSegment

		#region Line

		private void ImportLines()
		{
			SortedDictionary<string, object> cimLines = concreteModel.GetAllObjectsOfType("FTN.Line");
			if (cimLines != null)
			{
				foreach (KeyValuePair<string, object> cimLinePair in cimLines)
				{
					FTN.Line cimLine = cimLinePair.Value as FTN.Line;

					ResourceDescription rd = CreateLineResourceDescription(cimLine);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("Line ID = ").Append(cimLine.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("Line ID = ").Append(cimLine.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateLineResourceDescription(FTN.Line cimLine)
		{
			ResourceDescription rd = null;
			if (cimLine != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.LINE, importHelper.CheckOutIndexForDMSType(DMSType.LINE));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimLine.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateLineProperties(cimLine, rd, importHelper, report);
			}
			return rd;
		}

		#endregion Line

		#endregion Import
	}
}

