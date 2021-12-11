using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)

    {
        
        if (collision.gameObject.name == "leftEdge")
        {
            
            transform.position = transform.position + new Vector3(-18, 0, 0);
        }
        if (collision.gameObject.name == "rightEdge")
        {
            
            transform.position = transform.position + new Vector3(18, 0, 0);
        }
        if (collision.gameObject.name == "topEdge")
        {
            
            transform.position = transform.position + new Vector3(0, 0, 11);
        }
        if (collision.gameObject.name == "bottomEdge")
        {
            
            transform.position = transform.position + new Vector3(0, 0, -11);
        }


    }


}
