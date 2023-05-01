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

    [SerializeField]
    public GameObject Exit;

    [SerializeField]
    public GameObject TreatmentPre;

    [SerializeField]
    public GameObject TreatButton;

    [SerializeField]
    public GameObject TreatedText;

    #endregion

    public void ExitButton()
    {
        EmailScreen.SetActive(true);
        GameScreen.SetActive(false);
    }


    void StartButton(Patient patient,GameObject email, HashSet<Treatment> TreatementList)
    {
        
        Destroy(email);
        EmailScreen.SetActive(false);
        GameScreen.SetActive(true);
        PatientSceneManager.StartGame(patient,SymptomPre,SymptomContent,TreatmentContent,NameText,Exit,EmailScreen,GameScreen,TreatmentPre, TreatementList,TreatButton,TreatedText);
        //SceneManager.LoadScene();
    }

    public void OpenEmail(Patient patient,GameObject email, HashSet<Treatment> TreatementList)
    {
        //Sets from name
        From.GetComponent<TextMeshProUGUI>().text = patient.Name;

        //Activate Button
        Button button = Button.GetComponent<Button>();
        button.interactable = true;

        //Remove other patients from button and adds currently selected
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => StartButton(patient,email, TreatementList));
    }

    public void CreateEmail(Patient patient, HashSet<Treatment> TreatementList)
    {
        //Creates New object and sets the parent
        GameObject gamer = Instantiate(EmailPre, new Vector2(0, 0), Quaternion.identity);
        gamer.transform.SetParent(Content.transform, false);


        Transform bruh = gamer.transform.GetChild(0);
        TextMeshProUGUI cheese = bruh.gameObject.GetComponent<TextMeshProUGUI>();
        cheese.text = patient.Name;
        //This Maps the button on click to OpenEmail With the Given Patient
        gamer.GetComponent<Button>().onClick.AddListener( delegate () { OpenEmail(patient, gamer, TreatementList); });


    }


    // Start is called before the first frame update
        void Start()
    {

        //Sample Treatments
        HashSet<Treatment> TreatementList = new HashSet<Treatment>();

        Medicine Oseltamivir = new Medicine("Oseltamivir");
        Oseltamivir.MedicationType.Add(MedicationTypes.Antiviral);
        TreatementList.Add(Oseltamivir);

        Medicine Zanamivir = new Medicine("Zanamivir");
        Zanamivir.MedicationType.Add(MedicationTypes.Antiviral);
        TreatementList.Add(Zanamivir);

        //Sample Symptoms
        Symptom Fever = new Symptom("Fever");
        Symptom Cough = new Symptom("Cough");
        Symptom SoreThroat = new Symptom("Sore Throat");
        Symptom RunnyNose = new Symptom("Runny Nose");
        Symptom Headache = new Symptom("Headache");

        //Sample Inflictions


        //Flu
        Disease Flu = new Disease("Flu",true);
        Flu.Symptoms.Add(Fever);
        Flu.Symptoms.Add(Cough);
        Flu.Symptoms.Add(SoreThroat);
        Flu.Symptoms.Add(RunnyNose);
        Flu.Symptoms.Add(Headache);

        Flu.Treatements.Add(Oseltamivir);
        Flu.Treatements.Add(Zanamivir);

        //Sample Patients
        Patient patient = new Patient(Flu, "gamer");
        CreateEmail(patient,TreatementList);

        

    }
}
