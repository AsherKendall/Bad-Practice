using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Disease : Infliction
	{
		bool _isTreatable;
		string _name;
		List<Symptom> _symptoms;
		List<Treatment> _treatments;

		public bool IsTreatable
		{
			get
			{
				return _isTreatable;
			}
			set
			{
				_isTreatable = value;
			}
		}

		public Disease(string name) : base(name)
		{
			this.Name = name;
			_isTreatable = true;
		}

		public Disease(string name, bool isTreatable) : base(name)
		{
			Name = name;
			IsTreatable = isTreatable;
			Symptoms = new List<Symptom>();
			Treatements = new List<Treatment>();
		}
	}
}
