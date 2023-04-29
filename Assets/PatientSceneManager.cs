using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BadPractice.ClassSystem;
using UnityEngine.SceneManagement;


namespace PatientScreen
{

    public class PatientSceneManager : MonoBehaviour
    {
        // Start is called before the first frame update
        #region Fields
        

        #endregion
        static public void StartGame(Patient patient,GameObject SymptomPre,GameObject SymptomContent,GameObject NameText)
        {
            var nametext = NameText.GetComponent<TextMeshProUGUI>();
            nametext.text = patient.Name;
            foreach (Infliction i in patient.Inflictions)
            {
                foreach (Symptom s in i.Symptoms)
                {
                    GameObject SymptomPanel = Instantiate(SymptomPre, new Vector2(0, 0), Quaternion.identity);
                    SymptomPanel.transform.SetParent(SymptomContent.transform, false); //setParent

                    Transform Child = SymptomPanel.transform.GetChild(0);
                    TextMeshProUGUI bruh = Child.gameObject.GetComponent<TextMeshProUGUI>();
                    bruh.text = s.Name;
                }
            }

        }

    }



}

