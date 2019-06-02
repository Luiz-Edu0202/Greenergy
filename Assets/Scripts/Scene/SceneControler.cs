using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControler : MonoBehaviour
{
    public void ClickPlay()
    {
        SceneManager.LoadScene("GameFase1");
    }

    public void ClickOpcoes(){
        SceneManager.LoadScene("Opções");
    }

    public void ClickExit()
    {
        Application.Quit();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
         SceneManager.LoadScene("GameFase3");
    }

}
