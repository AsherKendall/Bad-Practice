using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Infliction
{
    private int _severity;
    private string _name;
    private string _description;
    private int _healthLoss;
    private enum _symptoms;
    private int _painLevel;

    internal virtual kill();
    internal virtual decreaseHealth();
    internal virtual newSymptom();
}

abstract class Disease : Infliction
{
    override private int _severity;
    override private string _name;
    override private string _description;
    override private int _healthLoss;
    private int _progression;
}

abstract class Infectious : Disease
{

}


abstract class Injury : Infliction
{
    
}


public class Patient
{
    private string _name;
    private int _health;
    private List<Infliction> inflictions;
}

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
