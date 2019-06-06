﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMovimento : MonoBehaviour
{
    [SerializeField]private float speed;
    public Vector3 direção;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direção * speed * Time.deltaTime);

        if (transform.position.y > 18f || transform.position.y <-18f || transform.position.x > 20f || transform.position.x < -20f )
        {

            Destroy(this.gameObject);

        }
    }
}
