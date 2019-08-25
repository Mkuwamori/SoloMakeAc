using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    GameObject targetingAnim;
    GameManager manager;
    

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;

        if (Vector3.Magnitude(transform.position - manager.player.transform.position) > 50)
            TargetCancel();
    }

    public void Targeting()
    {
        if (manager.TargetingList().Contains(gameObject))
            return;

        targetingAnim.SetActive(true);
        manager.AddTargetList(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Search")
            Targeting();
    }

    public void TargetRelease()
    {
        targetingAnim.SetActive(false);
    }
    public void TargetCancel()
    {
        targetingAnim.SetActive(false);
        if (!manager.TargetingList().Contains(gameObject))
            return;

        manager.RemoveTargetList(gameObject);
    }
}
