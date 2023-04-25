using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BadPractice.ClassSystem;
using UnityEngine.SceneManagement;

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



    void StartButton(Patient patient)
    {
        //SceneManager.LoadScene();
    }

    public void OpenEmail(Patient patient)
    {
        //Sets from name
        From.GetComponent<TextMeshProUGUI>().text = patient.Name;

        //Activate Button
        Button button = Button.GetComponent<Button>();
        button.interactable = true;

        //Remove other patients from button and adds currently selected
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => StartButton(patient));
    }

    public void CreateEmail(Patient patient,string Message)
    {
        //Creates New object and sets the parent
        GameObject gamer = Instantiate(EmailPre, new Vector2(0, 0), Quaternion.identity);f
        gamer.transform.SetParent(Content.transform, false);


        Transform bruh = gamer.transform.GetChild(0);
        TextMeshProUGUI cheese = bruh.gameObject.GetComponent<TextMeshProUGUI>();
        cheese.text = patient.Name;
        //This Maps the button on click to OpenEmail With the Given Patient
        print(gamer.gameObject.name);
        gamer.gameObject.GetComponent<Button>().onClick.AddListener(delegate() { this.OpenEmail(patient);  });


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
