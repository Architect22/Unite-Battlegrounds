using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Items")]
public class Item : ScriptableObject
{
    public int stacks = 0;
    public float attackBoost = 0;
    public string itemName = "";

    public virtual float CalculateStatBoost()
    {
        return attackBoost;
    }

    public void SetStacks(int amount)
    {
        stacks = amount;
    }
}