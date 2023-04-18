using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainClasses.ClassSystem;

public class EmailOnStart : MonoBehaviour
{
    [SerializeField]
    GameObject emailPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Patient patient = new Patient();
    }
}
