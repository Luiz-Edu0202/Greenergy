using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueGreen : MonoBehaviour
{
   //Variável de Velocidade Nula
    public static Vector2 speedNulo = new Vector3(0f,0f);

    public GameObject Green;
    public AudioClip fxSonoroTiro;
    public AudioSource Sons;

    public float nextFire;
    public float fireRate;

    [SerializeField] private GameObject ProjetilSD;
    [SerializeField] private GameObject ProjetilSE;
    [SerializeField] private GameObject ProjetilSC;
    [SerializeField] private GameObject ProjetilSB;

    // Start is called before the first frame update
    void Start()
    {
        Sons = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       atirar();
    }

    public void atirar(){
        
         ProjMovimento ScriptProjD = ProjetilSD.GetComponent<ProjMovimento>();
         ProjMovimento ScriptProjE = ProjetilSE.GetComponent<ProjMovimento>();
         ProjMovimento ScriptProjC = ProjetilSC.GetComponent<ProjMovimento>();
         ProjMovimento ScriptProjB = ProjetilSB.GetComponent<ProjMovimento>();

        //Atirando in Movimento
         if (Input.GetKeyUp(KeyCode.UpArrow) && GetComponent<Rigidbody2D>().velocity != speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjC.direção = Vector3.up;               
                nextFire = fireRate + Time.time;

                Instantiate(ProjetilSC, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow) && GetComponent<Rigidbody2D>().velocity != speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjB.direção = Vector3.down;               
                nextFire = fireRate + Time.time;

                Instantiate(ProjetilSB, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow) && GetComponent<Rigidbody2D>().velocity != speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjD.direção = Vector3.right;               
                nextFire = fireRate + Time.time;
            
                Instantiate(ProjetilSD, transform.position , Quaternion.identity); 
                fxTiroSimples();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) && GetComponent<Rigidbody2D>().velocity != speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjE.direção = Vector3.left;               
                nextFire = fireRate + Time.time;
            
                Instantiate(ProjetilSE, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }

        //Atirando Parado
        if (Input.GetKeyUp(KeyCode.UpArrow) && GetComponent<Rigidbody2D>().velocity == speedNulo )
        {
            if (Time.time > nextFire)
            {       
                ScriptProjC.direção = Vector3.up;               
                nextFire = fireRate + Time.time;

                Instantiate(ProjetilSC, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow) && GetComponent<Rigidbody2D>().velocity == speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjB.direção = Vector3.down;               
                nextFire = fireRate + Time.time;

                Instantiate(ProjetilSB, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow) && GetComponent<Rigidbody2D>().velocity == speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjD.direção = Vector3.right;               
                nextFire = fireRate + Time.time;
            
                Instantiate(ProjetilSD, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) && GetComponent<Rigidbody2D>().velocity == speedNulo)
        {
            if (Time.time > nextFire)
            {       
                ScriptProjE.direção = Vector3.left;               
                nextFire = fireRate + Time.time;
            
                Instantiate(ProjetilSE, transform.position, Quaternion.identity); 
                fxTiroSimples();
            }
        }
    }
    
    public void fxTiroSimples(){
            Sons.clip = fxSonoroTiro;
            Sons.Play();
        }
    }

