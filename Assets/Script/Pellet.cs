using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    //public int points = 10;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Rat")
            Destroy(gameObject);
    }
}
