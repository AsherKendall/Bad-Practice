using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public List<Infliction> Inflictions
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
			throw new NotImplementedException();
		}

		public void ApplyTreatment(Treatment treatment)
		{
			//Removes all inflictions that are treated
			if (treatment.GetType() == typeof(Antibiotic)) { _inflictions.RemoveAll(i => i.GetType() == typeof(Bacterial)); }

		}

		public Patient(Infliction infliction, string name)
		{
			_inflictions = new List<Infliction>();
			_inflictions.Add(infliction);
			_name = name;
		}

		public void LoadEmail()
		{
			
		}
	}
}
