using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Patient")]

namespace BadPractice.ClassSystem
{

	public class Infliction
	{
		string _name;
		private List<Symptom> _symptoms;
		private List<Treatment> _treatments;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		 public Infliction(string name)
		{
			Name = name;
		}

		public List<Symptom> Symptoms
		{
			get
			{
				return _symptoms;
			}
			set
			{
				_symptoms = value;
			}
		}

		public List<Treatment> Treatements
		{
			get
			{
				return _treatments;
			}
			set
			{
				_treatments = value;
			}
		}

		virtual protected internal bool Treat(Treatment treatment)
        {
			if(Treatements.Contains(treatment))
            {
				return true;
            }
			return false;
        }

		~Infliction()
		{
			_symptoms.Clear();
			_treatments.Clear();
		}
	}
}
