using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet_prefab;
    // Start is called befo6re the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire(Material material)
    {
        Vector3 pos = transform.position;
        GameObject new_bullet = Instantiate(bullet_prefab, pos, Quaternion.identity);
        new_bullet.GetComponent<Bullet>().material = material;
        Rigidbody rb = new_bullet.GetComponent<Rigidbody>();

        float theta = transform.rotation.eulerAngles.y*Mathf.PI / 180;
        float sin = Mathf.Sin(theta);
        float cos = Mathf.Cos(theta);

        //elev stands for elevation, it is the result of the angle of elevations
        float sin_elev = Mathf.Sin(-Mathf.PI/36);
        float cos_elev = Mathf.Cos(-Mathf.PI/36);

        rb.velocity = new Vector3(cos_elev*sin*50, -50*sin_elev, cos_elev*cos*50);
        
    }
}
