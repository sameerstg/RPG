
using UnityEngine;
[CreateAssetMenu(fileName = "Character", menuName = "Character")]
[System.Serializable]
public class Character :ScriptableObject
{

    public Abiblities abilities;
    public void GetDamage()
    {
        Debug.Log("Get hit");
    }
}

[System.Serializable]
public class Abiblities
{
    [SerializeField]public Flat attackValue;
    [SerializeField]public Flat healthValue;
    [SerializeField]public Flat defenceValue;
    [SerializeField]public Percentage resistanceValue;
    [SerializeField ]public Flat speed;
    [SerializeField]public Percentage agility;
    [SerializeField]public Flat weight;
    [SerializeField] public float attackingRange;

    
}

[System.Serializable]
public class Flat
{
    public float value;
}

[System.Serializable]
public class Percentage
{
    public float value;

}

