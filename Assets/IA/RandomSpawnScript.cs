using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnScript : MonoBehaviour
{
    public GameObject Enemy1, Enemy2, Enemy3; //Colocar aqui os prefabs dos inimigos
    public float spawnRate = 2f; //Tempo entre cada Spawn de inimigos
    public float nextSpawn; //Valor que vai se adicionar com o spawnRate
    public static float cont = 0f;
    public float Limitante; // Número de inimigos que esse spawner vai invocar
    int whatToSpawn; //Aleatoriedade do Spawn
    public static int contador=0;

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 4);
            switch (whatToSpawn)
            {
                
                case 1: 
                if(contador<Limitante)
                {
                    Instantiate(Enemy1, transform.position, Quaternion.identity);
                    cont++;
                    contador++;
                    nextSpawn = Time.time + spawnRate;
                }
                    break;
                case 2:
                if(contador<Limitante)
                {
                    Instantiate(Enemy2, transform.position, Quaternion.identity);
                    contador++;
                    nextSpawn = Time.time + spawnRate;
                }
                    break;
                case 3:
                if(contador<Limitante)
                {
                    Instantiate(Enemy3, transform.position, Quaternion.identity);
                    cont++;
                    contador++;
                    nextSpawn = Time.time + spawnRate;
                }
                    break;
                }
            
            }
        }
    }
