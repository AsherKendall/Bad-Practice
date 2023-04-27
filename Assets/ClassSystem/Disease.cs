using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadPractice.ClassSystem
{
	public class Disease : Infliction
	{
		List<Treatment> _treatments;
		List<Symptom> _symptoms;
		bool _isTreatable;
		string _name;

		 public Disease(string name)
        {
			_name = name;
        }

		public bool IsTreatable
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
	}
}
