using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using FTN.Services.NetworkModelService.DataModel.Wires;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FTN.Services.NetworkModelService
{
	public class Container
	{
		/// <summary>
		/// The dictionary of entities. Key = GlobaId, Value = Entity
		/// </summary>		
		public Dictionary<long, IdentifiedObject> Entities { get; set; } = new Dictionary<long, IdentifiedObject>();	

		/// <summary>
		/// Initializes a new instance of the Container class
		/// </summary>
		public Container() { }

		/// <summary>
		/// Gets a number of entitis in container
		/// </summary>		
		public int Count
		{
			get { return Entities.Count; }
		}

		/// <summary>
		/// Gets a value indicating whether container is empty
		/// </summary>		
		public bool IsEmpty
		{
			get { return Entities.Count == 0; }			
		}
			
		# region operators

		public static bool operator ==(Container x, Container y)
		{
			if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
			{
				return true;
			}
			else if ((ReferenceEquals(x, null) && !ReferenceEquals(y, null)) || (!ReferenceEquals(x, null) && ReferenceEquals(y, null)))
			{
				return false;
			}
			else
			{
				// TO DO
				if (x.Entities.Count != y.Entities.Count)
				{
					return false;
				}

				IdentifiedObject io = null;

				foreach (KeyValuePair<long, IdentifiedObject> pair in x.Entities)
				{
					//if (!y.objects.ContainsKey(pair.Key))
					if (y.Entities.TryGetValue(pair.Key, out io))
					{
						return false;
					}
					else if (io != pair.Value)
					{
						return false;
					}
				}

				 return true;									
			}
		}

		public static bool operator !=(Container x, Container y)
		{
			return !(x == y);
		}

		public override bool Equals (object obj)
		{
			return this == (Container)obj;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}				

		# endregion operators

		/// <summary>
		/// Creates entity for specified global inside the container.
		/// </summary>
		/// <param name="globalId">Global id of the entity for insert</param>		
		/// <returns>Created entity (identified object).</returns>
		public IdentifiedObject CreateEntity(long globalId) // DONE
		{
			short type = ModelCodeHelper.ExtractTypeFromGlobalId(globalId);

			IdentifiedObject io = null;			
			switch ((DMSType)type)
			{
				case DMSType.LINE:
					io = new Line(globalId);
					break;
				case DMSType.DCLINESEG:
					io = new DCLineSegment(globalId);
					break;
				case DMSType.ACLINESEG:
					io = new ACLineSegment(globalId);
					break;
				case DMSType.SERCOMP:
					io = new SeriesCompensator(globalId);
					break;
				case DMSType.SUBGEOREG:
					io = new SubGeographicalRegion(globalId);
					break;
				case DMSType.PERLENSEQIMP:
					io = new PerLengthSequenceImpedance(globalId);
					break;

				default:					
					string message = string.Format("Failed to create entity because specified type ({0}) is not supported.", type);
					CommonTrace.WriteTrace(CommonTrace.TraceError, message);
					throw new Exception(message);					
			}

			// Add entity to map
			this.AddEntity(io);

			return io;
		}		

		/// <summary>
		/// Checks if entity exists in container.
		/// </summary>
		/// <param name="globalId">Global id of the entity that should be checked</param>
		/// <returns>TRUE if the entity is found.</returns>
		public bool EntityExists(long globalId)
		{
			return Entities.ContainsKey(globalId);
		}	

		/// <summary>
		/// Returns entity (identified object) on the specified index. Throws an exception if entity does not exist. 
		/// </summary>
		/// <param name="index">Index of the entity that should be returned</param>
		/// <returns>Instance of the entity in case it is found on specified position, otherwise throws exception</returns>
		public IdentifiedObject GetEntity(long globalId)
		{
			if (EntityExists(globalId))
			{
				return Entities[globalId];
			}
			else
			{
				string message = string.Format("Failed to retrieve entity (GID = 0x{0:x16}) because entity doesn't exist.", globalId);
				CommonTrace.WriteTrace(CommonTrace.TraceError, message);
				throw new Exception(message);
			}
		}

		/// <summary>
		/// Adds entity on the first free position in the container.
		/// </summary>
		/// <param name="io">Entity (identified object) that should be added</param>
		/// <returns>Index of the entity that is just added.</returns>
		public void AddEntity(IdentifiedObject io)
		{
			if (!EntityExists(io.GlobalId))
			{
				Entities[io.GlobalId] = io;
			}
			else
			{
				string message = string.Format("Entity (GID = 0x{0:x16}) already exists.", io.GlobalId);
				CommonTrace.WriteTrace(CommonTrace.TraceError, message);
				throw new Exception(message);
			}
		}

		/// <summary>
		/// Removes entity from the container at the specified position. Throws an exception if entity does not exist.
		/// </summary>
		/// <param name="index">Index of the entity that should be removed</param>
		/// <returns>Returns entity that is removed</returns>
		public IdentifiedObject RemoveEntity(long globalId)
		{
			IdentifiedObject io = null;
			if (EntityExists(globalId))
			{
				Entities.Remove(globalId);
			}
			else
			{
				string message = string.Format("Failed to remove entity because entity with GID = {0} doesn't exist at the specified position ( {0} ).", globalId);
				CommonTrace.WriteTrace(CommonTrace.TraceError, message);
				throw new Exception(message);
			}

			return io;
		}

		/// <summary>
		/// Get globalIds of all entities.
		/// </summary>		
		/// <returns>Returns globalIds of all entities</returns>
		public List<long> GetEntitiesGlobalIds()
		{
			return Entities.Keys.ToList();
		}			
	}
}
