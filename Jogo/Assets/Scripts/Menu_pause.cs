using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_pause : MonoBehaviour
{
    public static Menu_pause mp;
    public GameObject Panel1;

    public void MenuPause()
    {
        Panel1.SetActive(true);
        Time.timeScale=0;
    }

    public void Continuar()
    {
        Panel1.SetActive(false);
        Time.timeScale=1;
    }
}
