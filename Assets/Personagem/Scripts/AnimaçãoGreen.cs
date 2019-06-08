using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoGreen : MonoBehaviour
{
    public Animator animAtual;
    public Animator animAndando;
    public Vector2 speedNulo;

    public GameObject Green;
    
    public float nextFire;
    public float fireRate;
    public bool atirou;

    // Start is called before the first frame update
    void Start() {
        animAtual = GetComponent<Animator>();
        atirou = false;
    }

    // Update is called once per frame
    void Update(){
        animMovimento();      
        animAtirar();
        Atirou();
        }

    public void Atirou(){
        if (atirou == true)
        {
           // StartCoroutine(IdAtirou());
        }
    }
    public void animMovimento(){
         //Anim - Andando Apenas
        if(GetComponent<Rigidbody2D>().velocity.x > 0 && !Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKeyUp(KeyCode.UpArrow) && !Input.GetKeyUp(KeyCode.DownArrow))
        {
            animAtual.SetBool("andarD", true);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", false);
            animAtual.SetBool("parado", false);
            
        }
      
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", true);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", false);
            animAtual.SetBool("parado", false);

        }
       
        else if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", true);
            animAtual.SetBool("andarB", false);
            animAtual.SetBool("parado", false);

        }
        
        else if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {  
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", true);
            animAtual.SetBool("parado", false);

        }

         if (GetComponent<Rigidbody2D>().velocity == speedNulo)
        {
            animAtual.SetBool("parado" , true);
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", false);
        }
    }
    public void animAtirar(){
        
        if(atirou == true){
            animAtual.SetBool("atirarD", false);  
            animAtual.SetBool("atirarE", false);
            animAtual.SetBool("atirarC", false);
            animAtual.SetBool("atirarB", false);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)){ 
            
             if (Time.time > nextFire){                      
                nextFire = fireRate + Time.time;
            
                animAtual.SetBool("atirarD", true);  
                animAtual.SetBool("atirarE", false);
                animAtual.SetBool("atirarC", false);
                animAtual.SetBool("atirarB", false);
            }
        }

         if(Input.GetKeyUp(KeyCode.LeftArrow)){

             if(Time.time > nextFire){
                nextFire = fireRate + Time.time;

                animAtual.SetBool("atirarE", true);  
                animAtual.SetBool("atirarD", false);
                animAtual.SetBool("atirarC", false);
                animAtual.SetBool("atirarB", false);
             }
           
        }

         if(Input.GetKeyUp(KeyCode.DownArrow)){

                if(Time.time > nextFire){
                    nextFire = fireRate + Time.time;            
                    
                    animAtual.SetBool("atirarB", true); 
                    animAtual.SetBool("atirarD", false);
                    animAtual.SetBool("atirarE", false);
                    animAtual.SetBool("atirarC", false);
            }
        }

         if(Input.GetKeyUp(KeyCode.UpArrow)){

              if(Time.time > nextFire){
                nextFire = fireRate + Time.time;     

                animAtual.SetBool("atirarC", true);  
                animAtual.SetBool("atirarD", false);
                animAtual.SetBool("atirarE", false);
                animAtual.SetBool("atirarB", false);
            } 
        }
      
    }

    IEnumerator IdAtirou(){
        yield return new WaitForSeconds(0.5f);
        atirou = false;
    }
}
