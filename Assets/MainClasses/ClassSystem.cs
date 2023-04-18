using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainClasses.ClassSystem
{
    #region Symptoms
    abstract public class Symptom
    {
        private string _location;
    }

    abstract public class Pain : Symptom
    {
        private string _painType;
        private int _severity;

    }

    #endregion


    #region Inflictions
    abstract class Infliction
    {
        private int _severity;
        private string _description;
        private int _healthLoss;
        //private enum _symptoms;
        private int _painLevel;

        //public virtual void kill();
        //public virtual int decreaseHealth();
        //public virtual void newSymptom();
    }

    abstract class Disease : Infliction
    {
        private int _severity;
        private string _description;
        private int _healthLoss;
        private int _progression;
    }

    


    #endregion
    /*/
    abstract class Infectious : Disease
    {

    }


    abstract class Injury : Infliction
    {

    }
    /*/

    public class Patient
    {
        private string _name;
        private int _health;
        private List<Infliction> _inflictions;

        Patient(Infliction infliction, string name)
        {
            _inflictions.Add(infliction);
            _name = name;
        }
    }
}



public class NewBehaviourScript : MonoBehaviour
{
    public string _name;

    /*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*/
}
