using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Bacterial : Infectious
	{
		private string _name;

		public Bacterial(string name)
        {
			_name = name;
        }
	}
}
