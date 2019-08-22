using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    float x, z;
    public Vector3 forward { get; set; }

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space))
            Float();
        if (Input.GetKey(KeyCode.LeftShift))
            Sink();
    }

    void Move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        transform.LookAt(transform.position + forward);
        rigid.MovePosition(transform.position + ((transform.right * x) + (transform.forward * z)) * 10 * Time.deltaTime);
    }

    void Float()
    {
        rigid.MovePosition(transform.position + Vector3.up * 10 * Time.deltaTime);
    }
    void Sink()
    {
        rigid.MovePosition(transform.position + Vector3.down * 10 * Time.deltaTime);
    }
}
