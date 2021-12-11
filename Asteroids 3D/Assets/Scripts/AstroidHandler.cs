using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            Vector3 forceDir = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
            child.transform.position = new Vector3(Random.Range(-8f, 8f), .7f, 5f);
            child.GetComponent<Rigidbody>().AddForce(forceDir);
        }
    }
}
