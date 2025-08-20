using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Items/AttackWeight")]
public class AttackWeight : Item {
    public override float CalculateStatBoost()
    {
        if (stacks > 6)
        {
            stacks = 6;
        }
        attackBoost = 18 + (12 * stacks);
        return attackBoost;
    }
}