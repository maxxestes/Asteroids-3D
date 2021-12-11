using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    void OnTriggerEnter(Collider collision)

    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "leftEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(-18, 0, 0);
        }
        if (collision.gameObject.name == "rightEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(18, 0, 0);
        }
        if (collision.gameObject.name == "topEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(0, 0, 11);
        }
        if (collision.gameObject.name == "bottomEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(0, 0, -11);
        }


    }
}