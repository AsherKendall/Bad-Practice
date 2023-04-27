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
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public Patient(Infliction infliction, string name)
		{
			throw new NotImplementedException();
		}
	}
}
