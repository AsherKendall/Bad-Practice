using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Infliction
{
    private int _severity;
    private string _name;
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
    private string _name;
    private string _description;
    private int _healthLoss;
    private int _progression;
}

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
    private List<Infliction> inflictions;
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
