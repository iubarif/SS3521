using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
	public interface IPlace
	{
		placeType TypeOfPlace { get; set; }
		string Alias { get; set; }
		place parent { get; set; }
		List<IPlace> ChildPlaces { get; }

		void AddAsChild(IPlace child);
		string PlaceInfo();
	}
}
