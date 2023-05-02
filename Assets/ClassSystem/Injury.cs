using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Injury : Infliction
	{
		string _location;
		string _name;
		List<Symptom> _symptoms;
		List<Treatment> _treatments;

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


        public Injury(string name, string location) : base(name)
		{
			Name = name;
			Location = location;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
