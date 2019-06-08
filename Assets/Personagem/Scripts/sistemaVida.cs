using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sistemaVida : MonoBehaviour
{
    public int vida = 3;
    public int numHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // variaveis do code dano
    // public bool morto = false;
    // public float danoTime = 1f;
    // public bool levouDano = false;

    void Start()
    {
        //um metodo de dano
        //LevouDano()
    }


    void Update()
    {

        
        Recarregacena();

        //vida não passa do num de hearts
        if (vida > numHearts)
        {
            vida = numHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (i < vida)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // seria o code pra diminuir vida
    // public void OnTriggerEnter2D(Collider2D col){
    //     if(col.CompareTag("enemy") && !levouDano){
    //         StartCoroutine(LevouDano());
    //     }
    // }
    //
    // public void OnCollisionEnter2D(Collision2D col){
    //     if(col.gameObject.CompareTag("enemy") && !levouDano){
    //         StartCoroutine(LevouDano());
    //     }
    // }

    // IEnumerator LevouDano(){
    //     levouDano = true;
    //     vida--;

    //     if(vida <= 0){
    //         morto = true;
    //         animação "morto"
    //         anim.SetTrigger("morto");
    //         recarregaria a cena
    //         Invoke("ReloadScene", 2f);
    //     } else {
    //         ignoraria a colisão
    //         deixaria o player invulnerável por um tempo depois de levar dano
    //         retornaria a colisão
    //         Physics2D.IgnoreLayerCollision(8, 9);
    //         for(float i = 0; i < danoTime; i+= 0.2f){
    //             GetComponent<SpriteRenderer>().enabled = false;
    //             yield return new WaitForSeconds(0.1f);
    //             GetComponent<SpriteRenderer>().enabled = true;
    //             yield return new WaitForSeconds(0.1f);
    //         }
    //         Physics2D.IgnoreLayerCollision(8, 9, false);
    //         levouDano = false;
    //     }
    // }

    //recarregaria a cena
    // void ReloadScene(){
    //     SceneManagement.LoadScene(SceneManagement.GetActiveScene().buildIndex);
    // }
    public void LevarDano()
    {
        vida--;
    }

    public void Recarregacena()
    {
        if (vida < 1)
        {
            SceneManager.LoadScene("GameOver1");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProj")
        {
            LevarDano();
        }
    }
   

    IEnumerator CDDano(){
        yield return new WaitForSeconds(2f);
    }
}

