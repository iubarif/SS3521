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
			if ((int)child.TypeOfPlace > (int)this.TypeOfPlace)
			{
				this.ChildPlaces.Add(child);
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
