using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Laceration : Injury
	{
		string _name;
		bool _needsStitches;
		List<Symptom> _symptoms;
		List<Treatment> _treatments;

		public bool NeedsStitches
		{
			get
			{
				return _needsStitches;
			}
			set
			{
				_needsStitches = value;
			}
		}

		public Laceration(string name, string location, bool IsBleeding, bool needsStitches) :base(name,location,IsBleeding)
		{
			Name = name;
			Location = location;
			this.IsBleeding = IsBleeding;
			NeedsStitches = needsStitches;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
