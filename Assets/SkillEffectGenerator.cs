using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectGenerator : MonoBehaviour
{
    public List<Attack> attacks = new List<Attack>();

    internal void InstantiateAttack(AttackType attackType,int multiplier)
    {

        foreach (var item in attacks)
        {
            if (attackType == item.attackType)
            {
                var obj = Instantiate(item.skillEffects[multiplier].skillEffect, item.skillEffects[multiplier].refPosition.transform.position,
                    Quaternion.identity);

                obj.transform.LookAt(GameManager._instance.enemyManager.GetClosestEnemy(obj.transform.position).transform.position);
                obj.AddComponent<GeneratedAttack>().SetAttackDetails(new AttackDetails(30));
            }
        }
    }
}
[System.Serializable]
public class Attack
{
    public AttackType attackType;
    public List<SkillEffect> skillEffects = new List<SkillEffect>();
}
[System.Serializable]
public class SkillEffect
{
    public InstantiatePosition instantiatePosition;
    public GameObject refPosition,skillEffect;
}
public enum InstantiatePosition
{
    EnemyPosition,AboveEnemy,AroundCharacter,AboveCharacter,RefPosition
}
public enum AttackType
{
    Combo,Skill1,Skill2,Ultimate
}

[System.Serializable]
public class AttackDetails
{
    internal float attackAmount;

    public AttackDetails(float attackAmount)
    {
        this.attackAmount = attackAmount;
    }
}
public enum AttackingWay
{
    ByDistance,ByParticleCollision
}