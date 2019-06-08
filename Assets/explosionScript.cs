using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Sair");
        Destroy(this.gameObject);
    }

    IEnumerator Sair(){
        yield return new WaitForSeconds(3f);
    }
}
