using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Internal : Injury
	{
		bool _blocked;
		string _name;
		List<Symptom> _symptoms;
		List<Treatment> _treatments;

		public bool Blocked
		{
			get
			{
				return _blocked;
			}
			set
			{
				_blocked = value;
			}
		}


		public Internal(string name, string location, bool IsBleeding, bool blocked) :base(name,location,IsBleeding)
		{
			Name = name;
			Location = location;
			this.IsBleeding = IsBleeding;
			Blocked = blocked;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
