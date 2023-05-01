using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Infectious : Disease
	{
		InfectionTypes _infectionType;
		string _name;
		bool _resistant;

		public InfectionTypes InfectionType
		{
			get
			{
				return _infectionType;
			}
		}

		public bool Resistant
		{
			get
            {
				return _resistant;
            }
            set
            {
				//Infectious dieases cannot stop being resistant
				if(value == true) { _resistant = value; };

				_resistant = false;
            }
		}

		override internal bool Treat(Treatment treatment)
        {
			if(treatment is Medicine)
            {
				if(Resistant == false)
                {
					if(InfectionType == InfectionTypes.Bacterial && ((Medicine)treatment).MedicationType.Contains(MedicationTypes.Antibiotic))
                    {
						return true;
                    }
					if (InfectionType == InfectionTypes.Fungal && ((Medicine)treatment).MedicationType.Contains(MedicationTypes.AntiFungal))
					{
						return true;
					}
				}
            }

			if (Treatements.Contains(treatment))
			{
				return true;
			}
			return false;
		}

		public Infectious(string name, bool isTreatable,bool resistant,InfectionTypes infectionType) :base(name,isTreatable)
        {
			Name = name;
			IsTreatable = isTreatable;
			_resistant = resistant;
			_infectionType = infectionType;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
