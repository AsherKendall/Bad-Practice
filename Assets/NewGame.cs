using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BadPractice.ClassSystem;


namespace BadPractice.GlobalData
{
    
    public class NewGame : MonoBehaviour
    {
        
        
        public void InitializeClasses()
        {
            //Gunshot
            List<Patient> patients = new List<Patient>();
            Bacterial Flu = new Bacterial("Flu");
            Patient patient = new Patient(Flu, "gamer");
            CreateEmail(patient);
        }
    }

}

