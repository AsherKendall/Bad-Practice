using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Patient
	{
		List<Infliction> _inflictions;
		double _temp;
		string _name;

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

		public double Temp
		{
			get
			{
				return _temp;
			}
			set
			{
				_temp = value;
			}
		}

		public List<Infliction> Inflictions
		{
			set
			{
				_inflictions = value;
			}
		}

		public void HealthUpdate()
		{
			throw new NotImplementedException();
		}

		public HashSet<Symptom> GetSymptoms()
        {
			HashSet<Symptom> SymptomsList = new HashSet<Symptom>();
			foreach(Infliction i in _inflictions)
            {
				foreach(Symptom s in i.Symptoms)
                {
					SymptomsList.Add(s);
                }
            }
			return SymptomsList;
        }

		public bool IsHealthy()
        {
			if(_inflictions.Count == 0)
            {
				return true;
            }

			return false;
        }

		~Patient()
		{
			_inflictions.Clear();
		}

		public List<Infliction> ApplyTreatment(Treatment treatment)
		{
			List<Infliction> RemovedInflictions = new List<Infliction>();
			foreach(Infliction i in _inflictions)
            {
				bool treated = i.Treat(treatment);
				if(treated)
                {
					RemovedInflictions.Add(i);
                }
            }

			foreach(Infliction i in RemovedInflictions)
            {
				_inflictions.Remove(i);
            }
			return RemovedInflictions;
		}

		public Patient(Infliction infliction, string name)
		{
			Inflictions = new List<Infliction>();
			_inflictions.Add(infliction);
			Name = name;
		}
	}
}
