using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedAttack : MonoBehaviour
{
    public AttackingWay attackingWay;
    public AttackDetails attackDetails;
    bool isAttacked;

    internal void SetAttackDetails(AttackDetails attackDetails) => this.attackDetails = attackDetails;
    
    private void Update()
    {
        if (!isAttacked&& Vector3.Distance( GameManager._instance.enemyManager.GetClosestEnemy(transform.position).transform.position,transform.position)<=2)
        {
            Debug.Log("Hitting enemy");
            isAttacked = true;
            GameManager._instance.enemyManager.GetClosestEnemy(transform.position).GetComponentInParent<Enemy>().GetHit(attackDetails.attackAmount);
        }
    }
}
