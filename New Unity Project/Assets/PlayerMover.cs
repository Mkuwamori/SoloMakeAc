using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    float x, z;
    public Vector3 forward { get; set; }

    void Start()
    {
        
    }
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        transform.LookAt(transform.position + forward);
        transform.position += ((transform.right * x) + (transform.forward * z)) * 10 * Time.deltaTime;
    }
}
