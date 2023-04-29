using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Physical : Treatment
	{
		string _location;
		string _name;

		public string Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		public Physical(string name, string location) : base(name)
		{
			Name = name;
			Location = location;
		}
	}
}
