using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectGenerator : MonoBehaviour
{
    public List<Attack> attacks = new List<Attack>();

    internal void InstantiateAttack(AttackType attackType,int multiplier)
    {

        Attack item = GetAttackByAttackType(attackType);
                var obj = Instantiate(item.skillEffects[multiplier].skillEffect, item.skillEffects[multiplier].refPosition.transform.position,
                    Quaternion.identity);
                if (item.skillEffects[multiplier].attackDirection == AttackDirection.TowardsEnemy)
                {
                    obj.transform.LookAt(GameManager._instance.enemyManager.GetClosestEnemy(obj.transform.position).transform.position);

                }
                else if(item.skillEffects[multiplier].attackDirection == AttackDirection.FrontOfCharacter)
                {
                    obj.transform.rotation = GameManager._instance.characterHolder.players[CharacterHolder.activeCharacterIndex].transform.rotation;
                }
                obj.AddComponent<GeneratedAttack>().SetAttackDetails(new AttackDetails(30));
                item.cooldown.UseCooldown();
                return;
            
        
    }
    public Attack GetAttackByAttackType(AttackType attackType)
    {

        foreach (var item in attacks)
        {
            if (attackType == item.attackType)
            {
                return item;
            }
        }
        return null;
    }

    private void Update()
    {
        foreach (var item in attacks)
        {
            
                item.cooldown.RunCooldownTime();
            
        }
    }
}
[System.Serializable]
public class Attack
{
    public AttackType attackType;
    public List<SkillEffect> skillEffects = new List<SkillEffect>();
    public CoolDown cooldown;
}
[System.Serializable]
public class SkillEffect
{
    public InstantiatePosition instantiatePosition;
    public GameObject refPosition,skillEffect;
    public AttackDirection attackDirection;
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
public enum AttackDirection
{
    FrontOfCharacter,TowardsEnemy
}
[System.Serializable]
public class CoolDown
{
    public float totalCooldownTime;
    public float cooldownTime;
    public float cooldownDecreasingAmount;


    public void RunCooldownTime()
    {
        if (cooldownTime<totalCooldownTime)
        {
            cooldownTime += Time.deltaTime;
        }
        
        if (cooldownTime>totalCooldownTime)
        {
            EndCoolDown();
        }
        
    }
    public bool IsCooldown()
    {
        if (cooldownTime >= cooldownDecreasingAmount)
        {
            return false;
        }
        if (cooldownTime < totalCooldownTime)
        {
            return true;
        }
        
        else
        {
            return false;
        }
    }
    public void EndCoolDown()
    {
        cooldownTime = totalCooldownTime;
    }
    public void UseCooldown()
    {
        cooldownTime -= cooldownDecreasingAmount;
        if (cooldownTime<0)
        {
            cooldownTime = 0;
        }
    }
}