using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject ControlsImage;

   public void Play()
    {
        SceneManager.LoadScene(1);
    }
     public void Controls()
    {
        ControlsImage.SetActive(true);
    }
}
