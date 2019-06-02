using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetMenu : MonoBehaviour
{
    [SerializeField] private bool desenvolvedor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (desenvolvedor == true && Input.GetKeyUp(KeyCode.Escape))
        {
            ChangeSceneF2();
        }
    }

    public void ChangeSceneF2()
    {
        SceneManager.LoadScene("Menu");
    }

}
