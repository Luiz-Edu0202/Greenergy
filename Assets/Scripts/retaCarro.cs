using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retaCarro : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float speed = 0.035f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<= 7)
        {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(transform.position.y>= 7)
        {
            SceneManager.LoadScene("CutscenePosFase2");
        }
    }
}
