using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float xiz = 0f;
    public bool batida;
    public bool paused;
    public GameObject telaPausa;
    public GameObject telaMorta;


    IEnumerator TimerPw()
	{	
        Instantiate(telaMorta, new Vector2(0.1f,1.6f), Quaternion.identity);
		yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameFase2");
        GetComponent<Renderer>().material.color = Color.white;
		batida = false;
	}
    void Start()
    {
        batida = false;
        transform.position = new Vector2(0f,-3.86f); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        pause();
    }

    private void Move()
    {
        if(Input.GetKeyDown(KeyCode.A) && batida == false)
        {
            xiz = xiz -6f;
        }
        
        if(Input.GetKeyDown(KeyCode.D) && batida == false)
        {
            xiz = xiz + 6f;
        }    
        
        if(xiz>6f){xiz=6f;}
        if(xiz<-6f){xiz=-6f;}
        transform.position = new Vector2(xiz,-3.86f);   
    }

    public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Colisor")
        {
            batida = true;
            GetComponent<Renderer>().material.color = Color.grey;
            StartCoroutine(TimerPw());
        }				
	}
        void pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0f;
            paused = true;
            batida = true;
            Instantiate(telaPausa, new Vector2(0.3f,1.5f), Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Time.timeScale = 1f;
            paused = false;
            batida = false;
        }

    }

}
