using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float xiz = 0f;
    public bool batida;
    public GameObject Canvas;
    //public GameObject telaMorta;


    IEnumerator TimerPw()
	{	
		yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver2");
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
        

}
