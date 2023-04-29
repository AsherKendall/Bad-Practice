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

		~Medicine()
		{
			MedicationType.Clear();
		}
	}
}
