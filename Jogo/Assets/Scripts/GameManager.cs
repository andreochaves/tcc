using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public static Alternativas[] alts;
    private int coins=0;
    int fases = 1;

    public int Fases
    {
        get 
        {
            return fases;
        }
    }

    void Awake()
    {
        if(gm==null)
        {
            gm=this;
            DontDestroyOnLoad(gameObject);
        }
        else if(gm!=this)
        {
            Destroy(gameObject);
        }
    }

    public void SetFases(int fase){
        if(fase>0)
        {
            fases += fase;
        }
    }

    public void SetCoins(int coin){
        if(coin>0)
        {
            coins += coin;
            AtualizaHud();
        }
    }

    public void novoJogoZero()
    {
            coins=0;
            AtualizaHud();
    }

    public void AtualizaHud()
    {
        GameObject.Find("CoinText").GetComponent<Text>().text=coins.ToString();

    }
}