using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControler : MonoBehaviour
{
    public void ClickPlay()
    {
        SceneManager.LoadScene("CutsceneInicial");
    }
    // public void ClickRestar()
    // {
    //     if (SceneNuber == "GameFase1")
    //     {
    //         SceneManager.LoadScene("GameFase1");
    //     }
    //     if (SceneName == "carrorrfase2")
    //     {
    //         SceneManager.LoadScene("carrorrfase2");
    //     }
    // }

    public void ClickOpcoes(){
        SceneManager.LoadScene("Opções");
    }

    public void ClickExit()
    {
        Application.Quit();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
         SceneManager.LoadScene("GameFase2");
    }

}
