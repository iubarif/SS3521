using System.IO;
using System.Text;

namespace Laboratory.Domain
{
	/*
     * Generates CSV file
     */

	public class CSVFileGenerator : IFileGenerator
	{
		private StringBuilder _csvContent;

		public CSVFileGenerator()
		{
			_csvContent = new StringBuilder();
		}

		public void GenerateFile(IPlace root)
		{
			var fileName = "actual.csv";

            // Delete file if already exist
            File.Delete(fileName);


			Traverse(root);

			if (_csvContent.Length != 0)
			{
				File.AppendAllText(fileName, _csvContent.ToString());
			}
		}

        // Traverse tree recursively
        private void Traverse(IPlace place)
		{
			if (place != null)
			{
				_csvContent.AppendLine(place.PlaceInfo());

				if (place.ChildPlaces.Count > 0)
				{
					foreach (var plc in place.ChildPlaces)
					{
						Traverse(plc);
					}
				}
			}

		}
	}
}
