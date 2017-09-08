using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
	public class dataTree
	{
		private IFileGenerator _fileGenerator;
		private IPlace _root;


		public dataTree(IFileGenerator fileGenerator)
		{
			_fileGenerator = fileGenerator;
			BuildDataTree();
		}

		private void BuildDataTree()
		{
			var building = new place { Alias = "Acme Lab", TypeOfPlace = placeType.Building };
			var tank = new place { Alias = "Tank 4", TypeOfPlace = placeType.Freezer };

			// Section 01
			var section1 = new place { Alias = "Section 1", TypeOfPlace = placeType.Section };

			for (int i = 0; i < 147; i++)
			{

				var tmpFrame = new place { Alias = string.Format("Frame {0}", (i + 1).ToString()), TypeOfPlace = placeType.Frame };

				for (int j = 0; j < 7; j++)
				{

					tmpFrame.AddAsChild(new place { Alias = string.Format("Position {0}", (j + 1).ToString()), TypeOfPlace = placeType.Position });
				}

				section1.AddAsChild(tmpFrame);

			}


			// Section 02
			var section2 = new place { Alias = "Section 2", TypeOfPlace = placeType.Section };


			for (int i = 0; i < 103; i++)
			{

				var tmpFrame = new place { Alias = string.Format("Frame {0}", (i + 1).ToString()), TypeOfPlace = placeType.Frame };

				for (int j = 0; j < 7; j++)
				{

					tmpFrame.AddAsChild(new place { Alias = string.Format("Position {0}", (j + 1).ToString()), TypeOfPlace = placeType.Position });
				}

				section2.AddAsChild(tmpFrame);

			}

			// Section 03
			var section3 = new place { Alias = "Section 3", TypeOfPlace = placeType.Section };

			// First set of Racks 
			for (int i = 0; i < 9; i++)
			{
				var rack = new place { Alias = string.Format("Rack {0}", (i + 1).ToString()), TypeOfPlace = placeType.Rack };

				for (int j = 0; j < 15; j++)
				{
					var level = new place { Alias = string.Format("Level {0}", (j + 1).ToString()), TypeOfPlace = placeType.Shelf };

					var box = new place { Alias = "Box (9x9)", TypeOfPlace = placeType.Box };

					for (int k = 0; k < 81; k++)
					{
						box.AddAsChild(new place { Alias = string.Format("Position {0}", (k + 1).ToString()), TypeOfPlace = placeType.Position });
					}

					level.AddAsChild(box);
					rack.AddAsChild(level);
				}

				section3.AddAsChild(rack);
			}


			// Second set of Racks
			for (int i = 9; i < 14; i++)
			{
				var rack = new place { Alias = string.Format("Rack {0}", (i + 1).ToString()), TypeOfPlace = placeType.Rack };

				for (int j = 0; j < 15; j++)
				{
					var level = new place { Alias = string.Format("Level {0}", (j + 1).ToString()), TypeOfPlace = placeType.Shelf };

					var box = new place { Alias = "Box (5x5)", TypeOfPlace = placeType.Box };

					for (int k = 0; k < 25; k++)
					{
						box.AddAsChild(new place { Alias = string.Format("Position {0}", (k + 1).ToString()), TypeOfPlace = placeType.Position });
					}

					level.AddAsChild(box);
					rack.AddAsChild(level);
				}

				section3.AddAsChild(rack);
			}

			// Integrate 
			tank.AddAsChild(section1);
			tank.AddAsChild(section2);
			tank.AddAsChild(section3);

			building.AddAsChild(tank);

			_root = building;
		}

		public void GenerateFile()
		{
			_fileGenerator.GenerateFile(_root);
		}
	}
}
