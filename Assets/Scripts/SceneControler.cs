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

}
