using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
    }


    public void StartButton()
    {
        SceneManager.LoadScene("EmailScreen");    }
}
