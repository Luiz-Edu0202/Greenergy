using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {
                                                //Esse inimigo corre atrás do player até certo ponto, se afasta se o Player chegar muito perto e atira enquanto isso//

    public float speed;
    public float stoppingDistance; //Distância pra o inimigo parar ao ver o player//
    public float retreatDistance; //Distância que o inimigo leva pra se distanciar do player//

    private float TempoEntreTiros;
    public float TempoInicialEntreTiros; //Coloca aqui o tempo entre cada bala//
    public GameObject GráficosDaBala; //Prefab da bala aqui//
    private Transform player; //Já colocou "Player" na tag do player, né?//

	// Use this for initialization
	public void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TempoEntreTiros = TempoInicialEntreTiros;
	}
	void Update () {

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //Inimigo seguindo o player//
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) //Inimigo parado//
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance) //Inimigo correndo do player//
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
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
