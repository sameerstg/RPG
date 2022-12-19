using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]public List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        
    }
    public GameObject GetClosestEnemy(Vector3 postion)
    {
        float leastDistance = 100000;
        GameObject closestEnemy = null;
        foreach (var item in enemies)
        {
            if (Vector3.Distance(item.transform.position,postion)<=leastDistance)
            {
                closestEnemy = item;
            }
        }
        return closestEnemy;
    }

}