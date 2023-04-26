using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BadPractice.ClassSystem;
using UnityEngine.SceneManagement;
using BadPractice.GlobalData;

public class EmailOnStart : MonoBehaviour
{

    [SerializeField]
    public GameObject EmailPre;

    [SerializeField]
    public GameObject Content;

    [SerializeField]
    public GameObject Button;

    [SerializeField]
    public GameObject From;
 
    void StartButton(Patient patient,GameObject email)
    {
        TheGuy = patient;
        Destroy(email);
        //SceneManager.LoadScene();
    }

    public void OpenEmail(Patient patient,GameObject email)
    {
        print("hi");
        //Sets from name
        From.GetComponent<TextMeshProUGUI>().text = patient.Name;

        //Activate Button
        Button button = Button.GetComponent<Button>();
        button.interactable = true;

        //Remove other patients from button and adds currently selected
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => StartButton(patient,email));
    }

    public void CreateEmail(Patient patient)
    {
        //Creates New object and sets the parent
        GameObject gamer = Instantiate(EmailPre, new Vector2(0, 0), Quaternion.identity);
        gamer.transform.SetParent(Content.transform, false);


        Transform bruh = gamer.transform.GetChild(0);
        TextMeshProUGUI cheese = bruh.gameObject.GetComponent<TextMeshProUGUI>();
        cheese.text = patient.Name;
        //This Maps the button on click to OpenEmail With the Given Patient
        print(gamer.gameObject.name);
        gamer.GetComponent<Button>().onClick.AddListener( delegate () { OpenEmail(patient, gamer); });


    }


    // Start is called before the first frame update
        void Start()
    {
        




        //Sample Symptoms

        //Sample Inflictions

        //Sample Patients

    }
}
