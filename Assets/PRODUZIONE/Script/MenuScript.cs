﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{

     Text punti,puntiMenu,puntiFinali; 
     GameObject settaggi,panel,panelFine,panelScore;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        panel = GameObject.Find("Panel");
        panelScore = GameObject.Find("PanelScore");
        panelFine = GameObject.Find("PanelFine");
        settaggi = GameObject.Find("Setting");
        puntiMenu = GameObject.Find("PuntiMenu").GetComponent<Text>();
        punti = GameObject.Find("Punti").GetComponent<Text>();
        puntiFinali = GameObject.Find("PuntiFinali").GetComponent<Text>();
        panel.gameObject.SetActive(false);
        panelFine.gameObject.SetActive(false);
        panelScore.gameObject.SetActive(true);
        Score.punteggio=0;
        Score.fine=false;    
    }

    // Update is called once per frame
    void Update()
    {


       if(Score.fine){
            apriMenuFine();                              
         }

    }

    public void apriMenu(){
        panelScore.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
       settaggi.gameObject.SetActive(false);
       punti.gameObject.SetActive(false);
        puntiMenu.text = "" + Score.punteggio;
       Time.timeScale=0;
    }

    public void apriMenuFine()
    {
        panelScore.gameObject.SetActive(false);
        panelFine.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
        settaggi.gameObject.SetActive(false);
        punti.gameObject.SetActive(false);
        puntiFinali.gameObject.SetActive(true);

        puntiFinali.text = "" + Score.punteggio;
        Time.timeScale = 0;
    }

    public void chiudiMenu(){
        panelScore.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
       settaggi.gameObject.SetActive(true);
        punti.gameObject.SetActive(true);
        Time.timeScale=1;
    }

    public void esci(){
        panelScore.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
       settaggi.gameObject.SetActive(true);
       SceneManager.LoadScene("Home");
       Score.punteggio=0;    
       Score.fine=false;
        Time.timeScale = 0;


    }

    public void ricomincia(){
        panelScore.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
       settaggi.gameObject.SetActive(true);
       SceneManager.LoadScene("Game");
       Score.punteggio=0;
       Score.fine = false;
        Time.timeScale = 0;


    }

}
