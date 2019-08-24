using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    float x, z;
    public Vector3 forward { get; set; }

    Rigidbody rigid;
    GameManager manager;

    [SerializeField]
    HomingLaser homingLaser;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        manager = GameObject.Find("manager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space))
            Float();
        if (Input.GetKey(KeyCode.LeftShift))
            Sink();

        if (Input.GetMouseButtonDown(1))
            Shot();
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

    void Shot()
    {
        List<GameObject> targets = manager.TargetingList();

        if (targets == null)
            return;

        for (int i = 0; i < 10; i++)
        {
            Instantiate(homingLaser, transform.position + Vector3.up, Quaternion.identity).Target(targets[(int)Mathf.Repeat(i, targets.Count)]);
        }
                
    }
}
