using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
	public interface IFileGenerator
	{
		void GenerateFile(IPlace root);
	}
}
