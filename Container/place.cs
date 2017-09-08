using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
	public class place : IPlace
	{
		public place()
		{
			this.ChildPlaces = new List<IPlace>();
		}

		public placeType TypeOfPlace { get; set; }
		public string Alias { get; set; }
		public place parent { get; set; }
		public List<IPlace> ChildPlaces { get; }

		public void AddAsChild(IPlace child)
		{
            // Child place type should be always greater than parent type. 
            // This ensures the hierarchy of places.
            if ((int)child.TypeOfPlace > (int)this.TypeOfPlace)
			{
				this.ChildPlaces.Add(child);

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

			place currentPlace = this;

            // Generating path from parent and grand(n) parent info
            while (currentPlace.parent != null)
			{
				parentpath = currentPlace.parent.Alias + (string.IsNullOrEmpty(parentpath) ? string.Empty : string.Format("/{0}", parentpath));
				currentPlace = currentPlace.parent;
			}

			var returnVal = string.Format("{0}, {1}, {2}", this.Alias, parentpath, this.TypeOfPlace.ToString());

			return returnVal;
		}

	}
}
