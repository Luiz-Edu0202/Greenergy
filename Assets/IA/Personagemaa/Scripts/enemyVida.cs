using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyVida : MonoBehaviour
{
    public int enemyVidaa = 2; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  
    
   
    void Update()
    {
        if(enemyVidaa <= 0){
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D colid)
        {
            // Debug.Log ("Oiwewew");
            
            Debug.Log(colid.tag);
            if(colid.gameObject.tag == "tiro")
            {
                enemyVidaa = enemyVidaa-1;
            }
        }
}
