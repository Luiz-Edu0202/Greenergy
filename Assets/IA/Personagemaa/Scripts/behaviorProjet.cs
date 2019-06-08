using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorProjet : MonoBehaviour
{

     [SerializeField]
    private float speed = 20f;

    public Vector3 direção;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    

        transform.Translate(direção * speed * Time.deltaTime);

        if (transform.position.y > 6f || transform.position.y <-6f || transform.position.x > 10f || transform.position.x < -10f )
        {

            Destroy(this.gameObject);

        }
    }
}
