using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMatado : MonoBehaviour {
  // Esse inimigo só faz correr atrás do Player//
    public GameObject explosion;
    public float speed; // Velocidade do inimigo//
    public bool mordida; // Determina se vai morder ou não//
    public float stopdist; // Muda no Unity esse valor pra a distância do inimigo parar antes de chegar no Player (pra não parar em cima dele)//
    private Transform target;
    public float xPosition;
    public Animator anim;
    public float x2;
    public float y2;
    public float yPosition;
    public static bool cima;
    public static bool baixo;
    public static bool esquerda;
    public static bool direita;
    public int aleatorio;
    private bool move;
    private bool moveV;
    public bool movimentaxion;
    public bool vacaOnline;
    public float retreatDistance; //Distância que o inimigo leva pra se distanciar do player//
    private float TempoEntreTiros;
    public float TempoInicialEntreTiros; //Coloca aqui o tempo entre cada bala//
    public GameObject GráficosDaBala; //Prefab da bala aqui//

    public int vidaEnemy = 3;

    

	void Start () {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Lembra de botar na Tag do Player "Player" (dã)//
	InvokeRepeating("verDireita",0f,0.5f);
        InvokeRepeating("chamar",0f,1f);
        aleatorio = Random.Range(1, 3); 
         
        }
       
	
	void Update () 
        {  
         verificaxion();
          movimentacao2();
          x2=this.transform.position.x;
          y2=this.transform.position.y;
          verDireita2();
          playerHorizontal();
          playerVertical();
          verCima();
          balitas();
          inimigoMorreu();
          animacao();
          //mordidao();
        }

        public void animacao(){
                if(direita == true){
                        anim.SetBool("Cima", false);
                        anim.SetBool("Baixo", false);
                        anim.SetBool("Direita", true);
                        anim.SetBool("Esquerda", false);
                }
                if(esquerda == true){
                        anim.SetBool("Cima", false);
                        anim.SetBool("Baixo", false);
                        anim.SetBool("Direita", false);
                        anim.SetBool("Esquerda", true);
                }
                if(cima == true){
                        anim.SetBool("Cima", true);
                        anim.SetBool("Baixo", false);
                        anim.SetBool("Direita", false);
                        anim.SetBool("Esquerda", false);
                }
                if(baixo == true){
                        anim.SetBool("Cima", false);
                        anim.SetBool("Baixo", true);
                        anim.SetBool("Direita", false);
                        anim.SetBool("Esquerda", false);
                }
        }
        void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "tiro")
        {
         vidaEnemy--;
        }
   }
           public void inimigoMorreu()
        {
           if(vidaEnemy <= 0)
           {
                RandomSpawnScript.cont--;
                RandomSpawnScript.contador--;  
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
           }
        }
        public void playerHorizontal()
        {
          if(target.position.x> this.transform.position.x )
          {
                  move=true;
          }
                
                 else
          {
                  move = false;
          }
        }

        public void playerVertical()
        {
          if(target.position.y>this.transform.position.y )
          {
                moveV =true;
          }
          else
          {
                moveV = false;
          }
        }
        public void verificaxion()
        {
                if(aleatorio == 2 &&  target.position.y < this.transform.position.y+0.2 &&  target.position.y > this.transform.position.y-0.2)
                {
                        print("aaaaaaaaa");
                        aleatorio=1;
                }
                if(aleatorio == 1 &&  target.position.x < this.transform.position.x+0.2 && target.position.x > this.transform.position.x-0.2 )
                {
                        print("Dddddd");
                        aleatorio=2;
                }
        }
        public void chamar()
        {
          StartCoroutine("movimentar");
          print ("abacaxi");
        
              
        }
         public void movimentacao2()
         {
                
             
                switch(aleatorio)
                {
                        case 1: 
                        //print("ladoo");
                        
                         if(move && Vector2.Distance(transform.position, target.position) > stopdist)
                        {

                           transform.Translate(Vector3.right  * speed * Time.deltaTime);
                           mordida=false;

                        }
                        else if (move == false && Vector2.Distance(transform.position, target.position) > stopdist)
                        {
                          transform.Translate(Vector3.left  * speed * Time.deltaTime);
                          mordida=false;
                        }
                        else if(move && Vector2.Distance(transform.position, target.position) < retreatDistance) //Inimigo correndo do player//
                        {
                                transform.Translate(Vector3.right  * -speed * Time.deltaTime);
                               
                        }
                        else if(move==false && Vector2.Distance(transform.position, target.position) < retreatDistance) //Inimigo correndo do player//
                        {
                                transform.Translate(Vector3.right  * speed * Time.deltaTime);
                               
                        } 
                                
                        break;

                        case 2:
                        //print("sobeee");
                         if(moveV && Vector2.Distance(transform.position, target.position) > stopdist)
                        {
                           transform.Translate(Vector3.up  * speed * Time.deltaTime);
                           mordida=false;
                        }
                        else if (moveV == false && Vector2.Distance(transform.position, target.position) > stopdist)
                        {
                          transform.Translate(Vector3.down  * speed * Time.deltaTime);
                          mordida=false;
                        } 
                        else if(moveV && Vector2.Distance(transform.position, target.position) < retreatDistance) //Inimigo correndo do player//
                        {
                                transform.Translate(Vector3.up  * -speed * Time.deltaTime);
                               
                        }
                        else if(moveV==false && Vector2.Distance(transform.position, target.position) < retreatDistance) //Inimigo correndo do player//
                        {
                                transform.Translate(Vector3.up  * speed * Time.deltaTime);
                               
                        }      
                        break;    
                }
         }
      



        public void verDireita()
        {
         xPosition = this.transform.position.x;
         //print(xPosition);
         yPosition = this.transform.position.y;
         //print(yPosition);
        }

        public void verDireita2()
        {
                 if(xPosition>x2)
                 {
                 // print("Esquerda");
                 baixo = false;
                 cima = false;
                 direita = false;
                 esquerda = true;
                 }
                 else if(xPosition<x2)
                 {
                //  print("Direita");
                 baixo = false;
                 cima = false;
                 direita = true;
                 esquerda = false;
                 }
        }

        public void verCima()
        {
              if(yPosition>y2)
                {
                // print("Pra baixo");
                 baixo = true;
                 cima = false;
                 direita = false;
                 esquerda = false;
                }
                else if(yPosition<y2)
                {
                // print("Pra cima");
                 baixo = false;
                 cima = true;
                 direita = false;
                 esquerda = false;
                }  
        }

         IEnumerator movimentar()
        {
            yield return new WaitForSeconds(2);
            aleatorio = Random.Range(1, 3); 
            print(aleatorio);
            
        
        
        }
        public void balitas()
        {
            if(TempoEntreTiros <= 0) //Invocando as balita
        {
            Instantiate(GráficosDaBala, transform.position, Quaternion.identity);
            TempoEntreTiros = TempoInicialEntreTiros;
        }
        else
        {
            TempoEntreTiros -= Time.deltaTime;
        }
        }
       

        
}