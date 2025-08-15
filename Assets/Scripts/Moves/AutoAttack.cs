using UnityEngine;
public class AutoAttack : Move
{
    public int boostCounter = 0;
    
    [Tooltip("How long your boosted stays before it's lost")]
    public float boostedCooldown = 0;
    private bool isBoosted = false;
}