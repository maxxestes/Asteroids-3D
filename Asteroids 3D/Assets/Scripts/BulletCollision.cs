using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject asteroid1Prefab;
    public GameObject asteroid2Prefab;
    public GameObject asteroid3Prefab;
    public GameObject scoreText;
    

    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "leftEdge")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "rightEdge")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "topEdge")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "bottomEdge")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Asteroid1")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject.Find("Score").GetComponent<scoringScript>().score += 30;
        }
        if (collision.gameObject.tag == "Asteroid2")
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newAsteroid = Instantiate(asteroid1Prefab, collision.transform.position, Quaternion.identity);
                Vector3 forceDir = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                newAsteroid.GetComponent<Rigidbody>().AddForce(forceDir);
                newAsteroid.tag = "Asteroid1"; //Why tf do I have to set this for it to work????????? It's set in the prefab???????????????????
                newAsteroid.transform.SetParent(GameObject.Find("AstroidHolder").GetComponent<Transform>());
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject.Find("Score").GetComponent<scoringScript>().score += 20;
        }
        if (collision.gameObject.tag == "Asteroid3")
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newAsteroid = Instantiate(asteroid2Prefab, collision.transform.position, Quaternion.identity);
                Vector3 forceDir = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                newAsteroid.GetComponent<Rigidbody>().AddForce(forceDir);
                newAsteroid.tag = "Asteroid2"; //???????????????????????
                newAsteroid.transform.SetParent(GameObject.Find("AstroidHolder").GetComponent<Transform>());
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject.Find("Score").GetComponent<scoringScript>().score += 10;
        }


    }
}
