using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGameplayUi : MonoBehaviour
{
    public GameObject slidersGo;
    public List<Slider> sliders = new List<Slider>();
    internal Slider comboSlider, skill1Slider, skill2Slider, ultimateSlider;
    private void Awake()
    {
        sliders = slidersGo.GetComponentsInChildren<Slider>().ToList();
        comboSlider = sliders[0];
        skill2Slider = sliders[1];
        skill1Slider = sliders[2];
        ultimateSlider = sliders[3];
    }
    
    private void Update()
    {
        Attack attack = CharacterHolder.activePlayerCs.skillEffectGenerator.GetAttackByAttackType(AttackType.Combo);
        comboSlider.value = attack.cooldown.cooldownTime/attack.cooldown.totalCooldownTime;
        attack = CharacterHolder.activePlayerCs.skillEffectGenerator.GetAttackByAttackType(AttackType.Skill1);
        skill1Slider.value = attack.cooldown.cooldownTime/attack.cooldown.totalCooldownTime;
        attack = CharacterHolder.activePlayerCs.skillEffectGenerator.GetAttackByAttackType(AttackType.Skill2);
        skill2Slider.value = attack.cooldown.cooldownTime/attack.cooldown.totalCooldownTime;
        attack = CharacterHolder.activePlayerCs.skillEffectGenerator.GetAttackByAttackType(AttackType.Ultimate);
        ultimateSlider.value = attack.cooldown.cooldownTime/attack.cooldown.totalCooldownTime;
    }
}
