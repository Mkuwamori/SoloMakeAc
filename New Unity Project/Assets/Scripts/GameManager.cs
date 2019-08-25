using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> targetEnemyList;
    
    public GameObject player { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        targetEnemyList = new List<GameObject>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddTargetList(GameObject add)
    {
        targetEnemyList.Add(add);
    }
    public void RemoveTargetList(GameObject rem)
    {
        targetEnemyList.Remove(rem);
    }

    public List<GameObject> TargetingList()
    {
        return targetEnemyList;
    }

    public void ClearTargetList()
    {
        foreach (var x in targetEnemyList)
        {
            x.GetComponent<Target>().TargetRelease();
        }
            
        targetEnemyList.Clear();
    }
}
