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
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    public void Targeting()
    {
        if (targetingAnim.activeInHierarchy == true)
            return;

        targetingAnim.SetActive(true);
        manager.AddTargetList(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Search")
            Targeting();
    }

    public void TargetCancel()
    {
        targetingAnim.SetActive(false);
    }
}
