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

		public static bool operator ==(Physical p1, Physical p2)
		{
			return p1.Name == p2.Name && p1.Location == p2.Location;

		}

		public static bool operator !=(Physical p1, Physical p2)
		{
			return p1.Name != p2.Name && p1.Location != p2.Location;

		}

		public Physical(string name, string location) : base(name)
		{
			Name = name;
			Location = location;
		}
	}
}
