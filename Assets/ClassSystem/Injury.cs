using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Injury : Infliction
	{
		bool _isBleeding;
		string _location;
		string _name;
		List<Symptom> _symptoms;
		List<Treatment> _treatments;

		public bool IsBleeding
		{
			get
			{
				return _isBleeding;
			}
			set
			{
				_isBleeding = value;
			}
		}

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


		public Injury(string name, string location, bool IsBleeding) : base(name)
		{
			Name = name;
			Location = location;
			this.IsBleeding = IsBleeding;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
