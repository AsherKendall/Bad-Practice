using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BadPractice.ClassSystem;
using UnityEngine.SceneManagement;
using PatientScreen;

public class EmailOnStart : MonoBehaviour
{
    #region Item Vars
    [SerializeField]
    public GameObject EmailPre;

    [SerializeField]
    public GameObject Content;

    [SerializeField]
    public GameObject Button;

    [SerializeField]
    public GameObject From;

    [SerializeField]
    public GameObject EmailScreen;

    [SerializeField]
    public GameObject GameScreen;

    [SerializeField]
    public GameObject NameText;

    [SerializeField]
    public GameObject SymptomContent;

    [SerializeField]
    public GameObject TreatmentContent;

    [SerializeField]
    public GameObject SymptomPre;
    #endregion

    public void ExitButton()
    {
        EmailScreen.SetActive(true);
        GameScreen.SetActive(false);
    }


    void StartButton(Patient patient,GameObject email)
    {
        
        Destroy(email);
        EmailScreen.SetActive(false);
        GameScreen.SetActive(true);
        PatientSceneManager.StartGame(patient,SymptomPre,SymptomContent,NameText);
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
        gamer.GetComponent<Button>().onClick.AddListener( delegate () { OpenEmail(patient, gamer); });


    }


    // Start is called before the first frame update
        void Start()
    {

        Symptom Fever = new Symptom("Fever");

        List<Patient> patients = new List<Patient>();
        Disease Flu = new Disease("Flu",true);
        Flu.Symptoms.Add(Fever);

        Patient patient = new Patient(Flu, "gamer");
        CreateEmail(patient);




        //Sample Symptoms

        //Sample Inflictions

        //Sample Patients

    }
}
