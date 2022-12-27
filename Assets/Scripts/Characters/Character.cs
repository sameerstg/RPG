
using UnityEngine;

/*public class Character
{

    public Abiblities baseAbilities = new();
    public Abiblities currentAbilities = new();
    public Abiblities totalAbilities = new();
    public Abiblities maxAbilities = new();
    internal void BalanceAbilities()
    {
        currentAbilities = totalAbilities = baseAbilities;

    }
    public void GetHit(float hitAmount)
    {
        Debug.Log("Get hit");
        if (currentAbilities.healthValue.value > 0)
        {
            currentAbilities.healthValue.value -= hitAmount;
        }

    }
}*/

[System.Serializable]
public class Abiblities
{
    [SerializeField] public Flat attackValue;
    [SerializeField] public Flat healthValue;
    [SerializeField] public Flat defenceValue;
    [SerializeField] public Percentage resistanceValue;
    [SerializeField] public Flat speed;
    [SerializeField] public Percentage agility;
    [SerializeField] public Flat weight;
    [SerializeField] public float attackingRange;


}

[System.Serializable]
public class Flat
{
    [Range(0, 999999999)]
    public float value;
}

[System.Serializable]
public class Percentage
{
    [Range(0, 100)]
    public float value;

}

