using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : MonoBehaviour
{
    GameObject target;
    Vector3 vector;
    int count;

    [SerializeField]
    GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        vector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)).normalized;
        count = 50;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vector.normalized * Time.deltaTime * 10;
        if (target == null)
            return;

        Vector3 vec = target.transform.position - transform.position;
        vector += (vec.normalized) / count;

        if (count <= 1)
            return;
        count -= 1;
    }

    public void Target(GameObject tg)
    {
        target = tg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
            return;

        Destroy(gameObject, 1);
        GetComponent<Collider>().enabled = false;
        target = null;
        vector = Vector3.zero;
        Instantiate(bomb, transform.position, Quaternion.identity);
    }
}
