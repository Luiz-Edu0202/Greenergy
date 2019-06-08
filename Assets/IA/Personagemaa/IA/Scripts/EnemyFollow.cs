using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
                                                // Esse inimigo só faz correr atrás do Player//
    public float speed; // Velocidade do inimigo//
    public bool mordida; // Determina se vai morder ou não//
    public float stopdist; // Muda no Unity esse valor pra a distância do inimigo parar antes de chegar no Player (pra não parar em cima dele)//
    private Transform target;
    public float xPosition;
    public float x2;
    public float y2;
    public float yPosition;
    public bool cima;
    public bool baixo;
    public bool esquerda;
    public bool direita;
    public int aleatorio;
    private bool move;
    private bool moveV;
    public bool movimentaxion;
    public bool vacaOnline;

    public int vidaEnemy = 2;
    

	void Start () {
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
          inimigoMorreu();
          //mordidao();
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
                RandomSpawnScript.contador--;
                RandomSpawnScript.cont--;   
                Destroy(this.gameObject);
           }
        }
        // public void mordidao()
        // {
        //         if(Vector2.Distance(transform.position, target.position) <= stopdist)
        //         {
        //                 mordida=true;
        //         }
        //         else
        //         {
        //                 movimentaxion= false;
        //         } 
        //          if(mordida)
        //          {
        //                  movimentaxion=true;
        //               if(move)
        //                 {
        //                    if(movimentaxion)
        //                    {    
        //                         StartCoroutine("mordedor");
        //                         float positionAntes=this.transform.position.x;
        //                         transform.Translate(Vector3.right  * speed * Time.deltaTime);
        //                         if(vacaOnline==false && this.transform.position.x != positionAntes)
        //                         {
        //                           transform.Translate(Vector3.left  * speed * Time.deltaTime);
        //                         }
        //                    }
                            

        //                 }
        //                 else if (move == false )
        //                 {
        //                   //transform.Translate(Vector3.left  * speed * Time.deltaTime);

        //                 }   
        //          }
        // }
        public void playerHorizontal()
        {
          if(target.position.x>this.transform.position.x )
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
                if(aleatorio == 2 &&  target.position.y < this.transform.position.y+stopdist &&  target.position.y > this.transform.position.y-stopdist)
                {
                        print("aaaaaaaaa");
                        aleatorio=1;
                }
                if(aleatorio == 1 &&  target.position.x < this.transform.position.x+stopdist && target.position.x > this.transform.position.x-stopdist )
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
                        break;    
                }
         }
        // public void movimentacao()
        // {
        //   if(Vector2.Distance(transform.position, target.position) > stopdist)
        // {
        // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // mordida = false;
	// }
        // if(Vector2.Distance(transform.position, target.position) <= stopdist)
        // {
        // mordida = true;
        // }
        // }



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
        // IEnumerator mordedor()
        // {
        //     yield return new WaitForSeconds(2);
        //    vacaOnline=false;
            
        
        
        // }


        
}