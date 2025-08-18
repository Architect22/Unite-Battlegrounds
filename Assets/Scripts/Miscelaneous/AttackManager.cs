using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public PlayablePokemon activePokemon;
    public List<PlayablePokemon> EnemyPokemon = new List<PlayablePokemon>();
    [SerializeField] private HealthBar healthBar;

    // put an animation curve in here for cpu damage behavior?
    public AnimationCurve cpuDamageBehavior;

    // pass a custom class into this function so that you can use multiple equations in one call
    public void DealDamage(float damage)
    {
        healthBar.DamageHealthbar(damage);
    }
}
