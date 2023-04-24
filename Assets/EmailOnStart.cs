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


    public void CreateEmail(Patient patient,string Message)
    {
        GameObject gamer = Instantiate(EmailPre, new Vector2(0, 0), Quaternion.identity);
        gamer.transform.SetParent(Content.transform, false);
        //gamer.GetComponent<Button>().onClick.AddListener(OnClick);
        Transform bruh = gamer.transform.GetChild(0);
        TextMeshProUGUI cheese = bruh.gameObject.GetComponent<TextMeshProUGUI>();
        cheese.text = patient.Name;
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        Bacterial Flu = new Bacterial("Flu");
        Patient patient = new Patient(Flu,"gamer");
        CreateEmail(patient,"I was shot!!!!!!");




        //Sample Symptoms

        //Sample Inflictions

        //Sample Patients

    }
}
