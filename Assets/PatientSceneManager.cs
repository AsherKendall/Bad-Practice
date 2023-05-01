using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BadPractice.ClassSystem;
using UnityEngine.SceneManagement;


namespace PatientScreen
{
    public class InflictionSymptoms
    {
        public List<GameObject> SymptomItems;
        public Infliction infliction;

        public InflictionSymptoms()
        {
            SymptomItems = new List<GameObject>();
        }
    }

    public class PatientSceneManager : MonoBehaviour
    {
        static void ExitGameScreen(Patient patient,GameObject EmailScreen,GameObject GameScreen)
        {
            EmailScreen.SetActive(true);
            GameScreen.SetActive(false);
        }

        static void TreatButtonClick(Patient patient,Treatment treatment,InflictionSymptoms SymptomTracker,GameObject Exit,GameObject TreatedText)
        {
            List<Infliction> TreatedInflictions = new List<Infliction>();
            TreatedInflictions = patient.ApplyTreatment(treatment);
            if(TreatedInflictions.Count != 0)
            {
                foreach(GameObject g in SymptomTracker.SymptomItems)
                {
                    Destroy(g);
                }
                TextMeshProUGUI TextBox = TreatedText.GetComponent<TextMeshProUGUI>();
                foreach (Infliction i in TreatedInflictions)
                {
                    TextBox.text += i.Name + ' ';
                }
                TextBox.text.Remove(TextBox.text.Length - 1, 1);
            }

            if (patient.Inflictions.Count == 0)
            {
                Exit.GetComponent<Button>().interactable = true;
            }
        }

        static void SymptomSelect(Patient patient,Treatment treatment,InflictionSymptoms SymptomTracker,GameObject Treatbutton,GameObject Exit,GameObject TreatedText)
        {
            Treatbutton.GetComponent<Button>().onClick.AddListener(delegate () { TreatButtonClick(patient,treatment,SymptomTracker,Exit,TreatedText); });
        }
        static public void StartGame(Patient patient,GameObject SymptomPre,GameObject SymptomContent,GameObject TreatmentContent,GameObject NameText,GameObject Exit,GameObject EmailScreen,GameObject GameScreen,GameObject TreatmentPre,HashSet<Treatment> TreatmentList,GameObject TreatButton,GameObject TreatedText)
        {
            var nametext = NameText.GetComponent<TextMeshProUGUI>();
            nametext.text = patient.Name;

            InflictionSymptoms SymptomTracker = new InflictionSymptoms();

            
            //Add Symptoms to ScrollView and To SymptomTracker
            foreach (Infliction i in patient.Inflictions)
            {
                foreach (Symptom s in i.Symptoms)
                {
                    GameObject SymptomPanel = Instantiate(SymptomPre, new Vector2(0, 0), Quaternion.identity);
                    SymptomPanel.transform.SetParent(SymptomContent.transform, false); //setParent
                    SymptomTracker.SymptomItems.Add(SymptomPanel);
                    Transform Child = SymptomPanel.transform.GetChild(0);
                    TextMeshProUGUI bruh = Child.gameObject.GetComponent<TextMeshProUGUI>();
                    bruh.text = s.Name;
                }
            }

            foreach(Treatment t in TreatmentList)
            {
                GameObject TreatmentItem = Instantiate(TreatmentPre, new Vector2(0, 0), Quaternion.identity);
                TreatmentItem.transform.SetParent(TreatmentContent.transform, false); //setParent
                Transform Child = TreatmentItem.transform.GetChild(0);
                TextMeshProUGUI bruh = Child.gameObject.GetComponent<TextMeshProUGUI>();
                bruh.text = t.Name;

                //Change button to do something here
                TreatmentItem.GetComponent<Button>().onClick.AddListener(delegate () { SymptomSelect(patient,t, SymptomTracker, TreatButton,Exit,TreatedText); });
            }


            Exit.GetComponent<Button>().onClick.AddListener(delegate () { ExitGameScreen(patient,EmailScreen,GameScreen); });

        }

    }



}

