using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> targetEnemyList;

    // Start is called before the first frame update
    void Start()
    {
        targetEnemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTargetList(GameObject add)
    {
        targetEnemyList.Add(add);
    }

    public List<GameObject> TargetingList()
    {
        return targetEnemyList;
    }
}
