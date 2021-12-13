using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Target")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = material;

            Debug.Log("Hit");
        }

        Destroy(gameObject);
    }
}
