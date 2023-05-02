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

        protected internal override bool Treat(Treatment treatment)
        {
			if (treatment is Physical && NeedsStitches)
			{
				if (((Physical)treatment).Location == Location && treatment.Name == "Stitches") ;
				{
					return true;
				}
			}

			if (Treatements.Contains(treatment))
			{
				return true;
			}
			return false;
		}


        public Laceration(string name, string location, bool needsStitches) :base(name,location)
		{
			Name = name;
			Location = location;
			NeedsStitches = needsStitches;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
