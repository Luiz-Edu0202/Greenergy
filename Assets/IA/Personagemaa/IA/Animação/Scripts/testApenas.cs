using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testApenas : MonoBehaviour
{
    public Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            a.SetBool("Direita", true);
            a.SetBool("Esquerda", false);
            a.SetBool("Cima", false);
            a.SetBool("Baixo", false);
        }

        if(Input.GetKey(KeyCode.A)){
            a.SetBool("Direita", false);
            a.SetBool("Esquerda", true);
            a.SetBool("Cima", false);
            a.SetBool("Baixo", false);
        }

        if(Input.GetKey(KeyCode.W)){
            a.SetBool("Direita", false);
            a.SetBool("Esquerda", false);
            a.SetBool("Cima", true);
            a.SetBool("Baixo", false);
        }

        if(Input.GetKey(KeyCode.S)){
            a.SetBool("Direita", false);
            a.SetBool("Esquerda", false);
            a.SetBool("Cima", false);
            a.SetBool("Baixo", true);
        }
    }
}
