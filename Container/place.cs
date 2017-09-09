using System;
using System.Collections.Generic;

namespace Laboratory.Domain
{
	public class Place : IPlace
	{
		public Place()
		{
			this.ChildPlaces = new List<IPlace>();
		}

		public PlaceType TypeOfPlace { get; set; }
		public string Alias { get; set; }
		public Place parent { get; set; }
		public List<IPlace> ChildPlaces { get; }

		public void AddAsChild(IPlace child)
		{
            // Child place type should be always greater than parent type. 
            // This ensures the hierarchy of places.
            if ((int)child.TypeOfPlace > (int)TypeOfPlace)
			{
				ChildPlaces.Add(child);

                // Establishing parent child relationship
                child.parent = this;
			}
			else
			{
				throw new Exception("Not a valid child!.");
			}
		}

		public string PlaceInfo()
		{
			var parentpath = string.Empty;

			Place currentPlace = this;

            // Generating path from parent and grand(n) parent info
            while (currentPlace.parent != null)
			{
				parentpath = currentPlace.parent.Alias + (string.IsNullOrEmpty(parentpath) ? string.Empty : $"/{parentpath}");
				currentPlace = currentPlace.parent;
			}

			return $"{Alias}, {parentpath}, {TypeOfPlace.ToString()}";

		}

	}
}
