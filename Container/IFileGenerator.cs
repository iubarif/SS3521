using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    /*
     * This service allows us to generate any kinds of file. 
     * Currently, we only need CSV but in future, we can generate JSON or XML. 
     * All we have to do is derive concrete classes that implement this interface.
     */

    public interface IFileGenerator
	{
		void GenerateFile(IPlace root);
	}
}
