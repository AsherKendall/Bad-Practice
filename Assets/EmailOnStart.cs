using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BadPractice.ClassSystem;

public class EmailOnStart : MonoBehaviour
{
    [SerializeField]
    public GameObject EmailPre;

    [SerializeField]
    public GameObject Content;


    public void CreateEmail(Patient patient)
    {
        var gamer = Instantiate(EmailPre, new Vector2(0, 0), Quaternion.identity);
        var texts = gamer.transform.GetChild(0);
        
        //THIS WON'T WORK BRUH BRUH BRUH
        var bruh = texts.GetComponentInParent<TextMesh>();
        bruh.text = patient.Name;
        gamer.transform.SetParent(Content.transform,false);
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        Bacterial Flu = new Bacterial("Flu");
        Patient patient = new Patient(Flu,"gamer");
        CreateEmail(patient);




        //Sample Symptoms

        //Sample Inflictions

        //Sample Patients

    }
}
