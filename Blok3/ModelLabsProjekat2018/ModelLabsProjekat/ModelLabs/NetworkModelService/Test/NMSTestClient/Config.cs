using System.Configuration;
using System.IO;

namespace FTN.Services.NetworkModelService.TestClient
{
	public class Config
	{

		public string ResultDirecotry { get; } = string.Empty;

		private Config()
		{
			ResultDirecotry = ConfigurationManager.AppSettings["ResultDirecotry"];

			if (!Directory.Exists(ResultDirecotry))
			{
				Directory.CreateDirectory(ResultDirecotry);
			}
		}

		#region Static members

		private static Config instance = null;

		public static Config Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Config();
				}

				return instance;
			}
		}

		#endregion Static members
	}
}
