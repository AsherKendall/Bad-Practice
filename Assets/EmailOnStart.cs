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


    void StartButton(Patient patient,GameObject email, HashSet<Treatment> TreatmentList, List<TreatButton> TreatmentButtons)
    {
        
        Destroy(email);
        EmailScreen.SetActive(false);
        GameScreen.SetActive(true);
        PatientSceneManager.StartGame(patient,SymptomPre,SymptomContent,TreatmentContent,NameText,Exit,EmailScreen,GameScreen,TreatmentPre, TreatmentList, TreatButton,TreatedText,TreatmentButtons);
        From.GetComponent<TextMeshProUGUI>().text = "";
        Button button = Button.GetComponent<Button>();
        button.interactable = false;
        //SceneManager.LoadScene();
    }

    public void OpenEmail(Patient patient,GameObject email, HashSet<Treatment> TreatmentList, List<TreatButton> TreatmentButtons)
    {
        //Sets from name
        From.GetComponent<TextMeshProUGUI>().text = patient.Name;

        //Activate Button
        Button button = Button.GetComponent<Button>();
        button.interactable = true;

        //Remove other patients from button and adds currently selected
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => StartButton(patient,email, TreatmentList, TreatmentButtons));
    }

    public void CreateEmail(Patient patient, HashSet<Treatment> TreatmentList, List<TreatButton> TreatmentButtons)
    {
        //Creates New object and sets the parent
        GameObject gamer = Instantiate(EmailPre, new Vector2(0, 0), Quaternion.identity);
        gamer.transform.SetParent(Content.transform, false);


        Transform bruh = gamer.transform.GetChild(0);
        TextMeshProUGUI cheese = bruh.gameObject.GetComponent<TextMeshProUGUI>();
        cheese.text = patient.Name;
        //This Maps the button on click to OpenEmail With the Given Patient
        gamer.GetComponent<Button>().onClick.AddListener( delegate () { OpenEmail(patient, gamer, TreatmentList, TreatmentButtons); });


    }


    // Start is called before the first frame update
        void Start()
    {

        //Sample Treatments
        HashSet<Treatment> TreatmentList = new HashSet<Treatment>();

        Medicine Oseltamivir = new Medicine("Oseltamivir");
        Oseltamivir.MedicationType.Add(MedicationTypes.Antiviral);
        TreatmentList.Add(Oseltamivir);

        Medicine Zanamivir = new Medicine("Zanamivir");
        Zanamivir.MedicationType.Add(MedicationTypes.Antiviral);
        TreatmentList.Add(Zanamivir);

        Physical ChemotherapyLungs = new Physical("Chemotherapy","Lungs");
        TreatmentList.Add(ChemotherapyLungs);

        Medicine Penicillin = new Medicine("Penicillin");
        Penicillin.MedicationType.Add(MedicationTypes.Antibiotic);
        TreatmentList.Add(Penicillin);

        Medicine PenicillinG = new Medicine("Penicllin G");
        PenicillinG.MedicationType.Add(MedicationTypes.Antibiotic);
        TreatmentList.Add(PenicillinG);

        //Sample Symptoms
        Symptom Fever = new Symptom("Fever");
        Symptom Cough = new Symptom("Cough");
        Symptom SoreThroat = new Symptom("Sore Throat");
        Symptom RunnyNose = new Symptom("Runny Nose");
        Symptom Headache = new Symptom("Headache");
        Symptom ChestPain = new Symptom("Chest Pain");
        Symptom CoughingBlood = new Symptom("Coughing Up Blood");
        Symptom Tiredness = new Symptom("Tiredness");
        Symptom WeightLoss = new Symptom("Weight Loss");
        Symptom Sweating = new Symptom("Sweating");
        Symptom FingernailsBlue = new Symptom("Fingernails turning blue");

        //Sample Inflictions

        //Lung Cancer
        Disease LungCancer = new Disease("LungCancer", true);
        LungCancer.Symptoms.Add(Cough);
        LungCancer.Symptoms.Add(ChestPain);
        LungCancer.Symptoms.Add(CoughingBlood);
        LungCancer.Symptoms.Add(Tiredness);
        LungCancer.Symptoms.Add(WeightLoss);

        LungCancer.Treatements.Add(ChemotherapyLungs);

        //Flu
        Infectious Flu = new Infectious("Flu",true,false,InfectionTypes.Viral);
        Flu.Symptoms.Add(Fever);
        Flu.Symptoms.Add(Cough);
        Flu.Symptoms.Add(SoreThroat);
        Flu.Symptoms.Add(RunnyNose);
        Flu.Symptoms.Add(Headache);

        Flu.Treatements.Add(Oseltamivir);
        Flu.Treatements.Add(Zanamivir);

        //Generic Bacterial Infection
        Infectious GenericalBacterial = new Infectious("Generic Bacterial Infection", true, false, InfectionTypes.Bacterial);
        GenericalBacterial.Symptoms.Add(Fever);
        GenericalBacterial.Symptoms.Add(Cough);
        GenericalBacterial.Symptoms.Add(Headache);
        GenericalBacterial.Symptoms.Add(Sweating);

        //Resistant Bacterial Infection
        Infectious ResistantPneumoniaBacterial =new Infectious("Resistant Pneumonia Bacterial Infection", true, false, InfectionTypes.Bacterial);
        ResistantPneumoniaBacterial.Symptoms.Add(Fever);
        ResistantPneumoniaBacterial.Symptoms.Add(Cough);
        ResistantPneumoniaBacterial.Symptoms.Add(Headache);
        ResistantPneumoniaBacterial.Symptoms.Add(Sweating);
        ResistantPneumoniaBacterial.Symptoms.Add(Tiredness);
        ResistantPneumoniaBacterial.Symptoms.Add(FingernailsBlue);

        ResistantPneumoniaBacterial.Treatements.Add(PenicillinG);

        //Create Treatment Buttons
        List<TreatButton> TreatmentButtons = new List<TreatButton>();
        TreatmentButtons = PatientSceneManager.GameScreenTreatmentLoad(TreatmentList, TreatmentPre, TreatmentContent);

        //Sample Patients
        Patient patient = new Patient(Flu, "Joe");
        CreateEmail(patient, TreatmentList, TreatmentButtons);

        Patient patient1 = new Patient(LungCancer, "Bob");
        CreateEmail(patient1, TreatmentList, TreatmentButtons);

        Patient patient2 = new Patient(GenericalBacterial, "Hamburger");
        CreateEmail(patient2, TreatmentList, TreatmentButtons);

        Patient patient3 = new Patient(ResistantPneumoniaBacterial, "John Brumles");
        CreateEmail(patient3, TreatmentList, TreatmentButtons);
    }
}
