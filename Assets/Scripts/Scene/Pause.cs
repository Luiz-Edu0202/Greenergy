using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Player;
    public bool paused = false;
    public GameObject telaPausa;
    public GameObject Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pause();
    }

    void pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0f;
            paused = true;
            Canvas.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Canvas.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
    }
}
