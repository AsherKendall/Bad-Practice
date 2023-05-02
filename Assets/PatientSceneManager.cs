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

    public class TreatButton
    {
        public Button button;
        public Treatment treatment;

        public TreatButton(Button button, Treatment treatment)
        {
            this.button = button;
            this.treatment = treatment;
        }

    }


    public class PatientSceneManager : MonoBehaviour
    {
        static void ExitGameScreen(Patient patient, GameObject EmailScreen, GameObject GameScreen, GameObject TreatedText, GameObject Treatbutton, Button ExitButton)
        {
            ExitButton.interactable = false;
            TreatedText.GetComponent<TextMeshProUGUI>().text = "";
            Treatbutton.GetComponent<Button>().onClick.RemoveAllListeners();
            EmailScreen.SetActive(true);
            GameScreen.SetActive(false);
        }

        static void TreatButtonClick(Patient patient, Treatment treatment, InflictionSymptoms SymptomTracker, GameObject Exit, GameObject TreatedText)
        {
            List<Infliction> TreatedInflictions = new List<Infliction>();
            TreatedInflictions = patient.ApplyTreatment(treatment);
            if (TreatedInflictions.Count != 0)
            {
                foreach (GameObject g in SymptomTracker.SymptomItems)
                {
                    Destroy(g);
                }
                TextMeshProUGUI TextBox = TreatedText.GetComponent<TextMeshProUGUI>();
                foreach (Infliction i in TreatedInflictions)
                {
                    if(i is Injury)
                    {
                        TextBox.text += i.Name + "(" + ((Injury)i).Location + ")";
                    }
                    else{TextBox.text += i.Name;}
                }
                TextBox.text.Remove(TextBox.text.Length - 1, 1);
            }

            if (patient.IsHealthy())
            {
                Exit.GetComponent<Button>().interactable = true;
            }
        }

        static void SymptomSelect(Patient patient, Treatment treatment, InflictionSymptoms SymptomTracker, Button button, GameObject Exit, GameObject TreatedText)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(delegate () { TreatButtonClick(patient, treatment, SymptomTracker, Exit, TreatedText); });
        }
        static public void StartGame(Patient patient, GameObject SymptomPre, GameObject SymptomContent, GameObject TreatmentContent, GameObject NameText, GameObject Exit, GameObject EmailScreen, GameObject GameScreen, GameObject TreatmentPre, HashSet<Treatment> TreatmentList, GameObject Treatment, GameObject TreatedText,List<TreatButton>TreatmentButtons)
        {
            var nametext = NameText.GetComponent<TextMeshProUGUI>();
            nametext.text = patient.Name;

            InflictionSymptoms SymptomTracker = new InflictionSymptoms();


            //Add Symptoms to ScrollView and To SymptomTracker

            foreach (Symptom s in patient.GetSymptoms())
            {
                GameObject SymptomPanel = Instantiate(SymptomPre, new Vector2(0, 0), Quaternion.identity);
                SymptomPanel.transform.SetParent(SymptomContent.transform, false); //setParent
                SymptomTracker.SymptomItems.Add(SymptomPanel);
                Transform Child = SymptomPanel.transform.GetChild(0);
                TextMeshProUGUI bruh = Child.gameObject.GetComponent<TextMeshProUGUI>();
                if(s.Location != null)
                {
                    bruh.text = s.Name + '(' + s.Location + ')';
                }
                else
                {
                    bruh.text = s.Name;
                }
                    
            }


            Button TreatmentButton = Treatment.GetComponent<Button>();
            foreach (TreatButton b in TreatmentButtons)
            {
                b.button.onClick.RemoveAllListeners();
                b.button.onClick.AddListener(delegate () { SymptomSelect(patient, b.treatment, SymptomTracker, TreatmentButton, Exit, TreatedText); });
            }

            Button ExitButton = Exit.GetComponent<Button>();
            Exit.GetComponent<Button>().onClick.AddListener(delegate () { ExitGameScreen(patient, EmailScreen, GameScreen, TreatedText, Treatment, ExitButton); });
        }

        static public List<TreatButton> GameScreenTreatmentLoad(HashSet<Treatment> TreatmentList,GameObject TreatmentPre,GameObject TreatmentContent)
        {
            List<TreatButton> TreatmentButtons = new List<TreatButton>();
            foreach (Treatment t in TreatmentList)
            {
                GameObject TreatmentItem = Instantiate(TreatmentPre, new Vector2(0, 0), Quaternion.identity);
                TreatmentItem.transform.SetParent(TreatmentContent.transform, false); //setParent
                Transform Child = TreatmentItem.transform.GetChild(0);
                TextMeshProUGUI bruh = Child.gameObject.GetComponent<TextMeshProUGUI>();

                TreatmentButtons.Add(new TreatButton(TreatmentItem.GetComponent<Button>(), t));

                if (t is Physical)
                {
                    bruh.text = t.Name + "(" + ((Physical)t).Location + ")";
                }
                else
                {
                    bruh.text = t.Name;
                }
            }
            return TreatmentButtons;
        }

    }
}
