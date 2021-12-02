using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float rotation_speed = 720f;
    public float walking_speed = 10f;
    public GameObject gun;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation_x = Input.GetAxis("Mouse X");
        
        if(rotation_x != 0)
        {
            transform.Rotate(0,rotation_x*Time.deltaTime*rotation_speed, 0);
        }

        float theta = (transform.rotation.eulerAngles.y * Mathf.PI) / 180;

        float sin = Mathf.Sin(theta);
        float cos = Mathf.Cos(theta);

        Vector3 v = new Vector3(0,0,0);
        if(Input.GetKey(KeyCode.W))
        {
            v.z += 1;
        }

        if(Input.GetKey(KeyCode.S))
        {
            v.z += -1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            v.x += 1;
        }

        if(Input.GetKey(KeyCode.A))
        {
            v.x += -1;
        }

        if(v.magnitude != 0)
        {
            v.x *= walking_speed*Time.deltaTime/v.magnitude;
            v.z *= walking_speed*Time.deltaTime/v.magnitude;
        }

        Vector3 u = new Vector3();
        u.x = (v.x*cos) + (v.z * sin);
        u.y = v.y;
        u.z = (v.z*cos) - (v.x * sin);

        transform.Translate(u,Space.World);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Gun script = gun.GetComponent<Gun>();
            script.fire();
        }
    }
}
