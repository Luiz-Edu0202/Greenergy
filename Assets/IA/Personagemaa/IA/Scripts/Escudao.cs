using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudao : MonoBehaviour
{
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
    private int vidaEscudo = 4;
    public bool semEscudo = false;
    private Transform player;
    public float inimgoDistance;
    public bool defendedor;
    public float personagemDistance=2;

	void Start () {
         // Lembra de botar na Tag do Player "Player" (dã)//
	InvokeRepeating("verDireita",0f,0.5f);
        InvokeRepeating("chamar",0f,1f);
        aleatorio = Random.Range(1, 3);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
         
        }
       
	
	void Update () 
        {
          print(RandomSpawnScript.cont);
          if(RandomSpawnScript.cont>0)
          {
            target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
          }
          else{
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
          }
          verificaxion();
          movimentacao2();
          x2=this.transform.position.x;
          y2=this.transform.position.y;
          verDireita2();
          playerHorizontal();
          playerVertical();
          verCima();
          escudeiraCaiuBoom();
          pegarPosition();
          // defender2();
         
        }

        public void pegarPosition()
        {
          

        }
        void OnTriggerEnter2D(Collider2D col)
   {
        if(col.tag == "tiro")
        {
         vidaEscudo--;
        }
        if(vidaEscudo<-1)
        {
          RandomSpawnScript.contador--;
          Destroy(this.gameObject);
        }
   }
  //  public void agir(){
  //    if(InimigoA = 0)
  //    {
  //      target = player;
  //    }
  //  }
      // public void defender2()
      // {
      //    if(direita && target.transform.position.x-this.transform.position.x < personagemDistance + 1 ||  this.transform.position.x-aliado.transform.position.x == inimgoDistance)
      //    {
      //        defendedor=true;
      //    }
      //    else if(esquerda && this.transform.position.x-target.transform.position.x == personagemDistance && aliado.transform.position.x-this.transform.position.x == inimgoDistance)
      //    {
      //      defendedor=true;
      //    }
      //    else if(cima && target.transform.position.y-this.transform.position.y == personagemDistance &&  this.transform.position.x-aliado.transform.position.x == inimgoDistance)
      //    {
      //        defendedor=true;
      //    }
      //    else if(baixo && this.transform.position.y-target.transform.position.y == personagemDistance && aliado.transform.position.x-this.transform.position.x == inimgoDistance)
      //    {
      //      defendedor=true;
      //    }
      //    else
      //    {
      //      defendedor=false;
      //    }
      // }
        // public void defender(){
        //   if(EnemyMatado.baixo == true)
        //   {
        //     this.transform.position = new Vector3(aliado.position.x,aliado.position.y-inimgoDistance,0f);

        //   }
        //   else if(EnemyMatado.cima == true)
        //   {
        //     this.transform.position = new Vector3(aliado.position.x,aliado.position.y+inimgoDistance,0f);

        //   }   
        //   else if(EnemyMatado.esquerda == true)
        //   {
        //     this.transform.position = new Vector3(aliado.position.x-inimgoDistance,aliado.position.y,0f);

        //   }   
        //   else if(EnemyMatado.direita == true)
        //   {
        //     this.transform.position = new Vector3(aliado.position.x+inimgoDistance,aliado.position.y,0f);

        //   }      
        // }
        public void escudeiraCaiuBoom()
        {
           //print(vidaEscudo + " Vida");
           //print(EnemyMatado.baixo);
           if(vidaEscudo <= 0)
           {
                semEscudo = true;
           }
        }
        
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
                        //print("aaaaaaaaa");
                        aleatorio=1;
                }
                if(aleatorio == 1 &&  target.position.x < this.transform.position.x+stopdist && target.position.x > this.transform.position.x-stopdist )
                {
                        //print("Dddddd");
                        aleatorio=2;
                }
        }
        public void chamar()
        {
          StartCoroutine("movimentar");
          //print ("abacaxi");
        
              
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
        


        
}