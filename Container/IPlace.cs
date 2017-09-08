using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{

    /*
     *  Base contract for every place. 
     *  The benefit of using Interface: 
     *  In future, if the business dictates different rules for parent child relationship or 
     *  for different representation of nodes we just have to derive another concrete class from this interface.
     */

    public interface IPlace
	{
		placeType TypeOfPlace { get; set; }
		string Alias { get; set; }
		place parent { get; set; }
		List<IPlace> ChildPlaces { get; }

        /// <summary>
        /// Add child places to parent. also, this is a suitable place impose some validation rules
        /// </summary>
        /// <param name="child"></param>
        void AddAsChild(IPlace child);

        /// <summary>
        /// Represent individual Place. ex: alias, path, place type
        /// </summary>
        /// <returns></returns>
        string PlaceInfo();
	}
}
