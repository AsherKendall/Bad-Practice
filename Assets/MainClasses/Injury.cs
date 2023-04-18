using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainClasses.ClassSystem;


abstract class Injury : Infliction
{
    private int _severity;
    private string _name;
    private string _description;
    private int _healthLoss;
}
class GunShotWound : Injury
{
    private string _location;
    private bool _isBleeding;
    private string _healthLoss;
    private int _severity;
}