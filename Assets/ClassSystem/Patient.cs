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
			get
			{
				return _inflictions;
			}
			set
			{
				_inflictions = value;
			}
		}

		public void HealthUpdate()
		{
			throw new NotImplementedException();
		}

		private void Die()
		{
			throw new NotImplementedException();
		}

		~Patient()
		{
			_inflictions.Clear();
		}

		public List<string> ApplyTreatment(Treatment treatment)
		{
			List<string> RemovedInflictions = new List<string>();
			foreach(Infliction i in Inflictions)
            {
				bool treated = i.Treat(treatment);
				if(treated)
                {
					RemovedInflictions.Add(i.Name);
					Inflictions.Remove(i);
                }
            }
			return RemovedInflictions;
		}

		public Patient(Infliction infliction, string name)
		{
			Inflictions.Add(infliction);
			Name = name;
		}
	}
}
