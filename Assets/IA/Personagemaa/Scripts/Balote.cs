using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balote : MonoBehaviour {
                                                //Coloca esse código no Prefab da bala que vai ser invocada e coloca esse Prefab no Public do EnemyShooter em "Gráficos da Bala"//
    public float speed; //Velocidade da bala, joga e muda no Prefab que você fizer da bala
    private Transform player;
    private Vector2 target;


	// Use this for initialization
	public void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player").transform; //Lembra de botar "Player" na tag pelo amor de Deus
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
    public	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //Se quiser que a bala siga o jogador depois de se mover, mudar "target" para player.position (é bem roubado, cuidado)
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestruirBala();
        }

	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestruirBala();
        }
    }
    public void DestruirBala()
    {
        Destroy(this.gameObject);
    }
    IEnumerator DestroyShot ()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
