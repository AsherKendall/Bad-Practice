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

        protected internal override bool Treat(Treatment treatment)
        {
			if(Blocked)
            {
				if(treatment is Physical)
                {
					if(((Physical)treatment).Name == "Removal" && ((Physical)treatment).Location == Location)
                    {
						Blocked = false;
					}
                }
				return false;
            }
            return base.Treat(treatment);
        }

        public Internal(string name, string location, bool blocked) :base(name,location)
		{
			Name = name;
			Location = location;
			Blocked = blocked;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
