using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Medicine : Treatment
	{
		List<MedicationTypes> _medicationType;
		string _name;

		public List<MedicationTypes> MedicationType
		{
			get
			{
				return _medicationType;
			}
			set
			{
				_medicationType = value;
			}
		}

		public Medicine(string name) : base(name)
		{
			Name = name;
			MedicationType = new List<MedicationTypes>();
		}

		public static bool operator ==(Medicine m1, Medicine m2)
		{
			return m1.Name == m2.Name && m1.MedicationType == m2.MedicationType;

		}

		public static bool operator !=(Medicine m1, Medicine m2)
		{
			return m1.Name != m2.Name && m1.MedicationType != m2.MedicationType;

		}

		~Medicine()
		{
			MedicationType.Clear();
		}
	}
}
