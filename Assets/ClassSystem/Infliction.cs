using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public abstract class Infliction
	{
		string _name;
		List<Treatment> _treatments;
		List<Symptom> _symptoms;

		public List<Symptom> Symptoms
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public List<Treatment> Treatments
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
		Infliction(string name)
        {
			_name = name;
        }

        public Infliction()
        {
			_name = null;
        }
	}
}
