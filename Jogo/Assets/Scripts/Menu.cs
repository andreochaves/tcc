using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Panel2;
    public GameManager gm;
     public float volumeFX,volumeMusica;

    public Slider sMusica,sFX;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("VOLUME")) 
        {
            volumeFX = PlayerPrefs.GetFloat("VOLUME");
            sFX.value = volumeFX;
            AudioListener.volume = volumeFX;
            volumeMusica = PlayerPrefs.GetFloat("VOLUME");
            sMusica.value = volumeMusica;
            AudioListener.volume = volumeMusica;
        } 
        else 
        {
            PlayerPrefs.SetFloat("VOLUME", 1);
            sFX.value = 1;
            PlayerPrefs.SetFloat("VOLUME", 1);
            sMusica.value = 1;
        }
    }
    public void NovoJogo()
    {
        SceneManager.LoadScene("Capitulo 1");
        gm.novoJogoZero();
    }

     public void Opcoes()
    {
        Panel2.SetActive(true);
    }
    public void VoltarMenu()
    {
        Panel2.SetActive(false);
    }
    public void VolumeFx(float volume)
    {
        volumeFX = volume;
        GameObject[] FXs = GameObject.FindGameObjectsWithTag("Fx");
        for(int i=0;i<FXs.Length;i++)
        {
            FXs[i].GetComponent<AudioSource>().volume=volumeFX;
        }
    }

    public void VolumeMusica(float volume)
    {
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for(int i=0;i<Musicas.Length;i++)
        {
            Musicas[i].GetComponent<AudioSource>().volume=volumeMusica;
        }
    }

    public void BtMinMusica()
    {
        VolumeMusica(0);
        sMusica.value=0;
    }

     public void BtMaxMusica()
    {
        VolumeMusica(1);
        sMusica.value=1;
    }

     public void BtMinFX()
    {
        VolumeFx(0);
        sFX.value=0;
    }

     public void BtMaxFX()
    {
        VolumeFx(1);
        sFX.value=1;
    }
}
