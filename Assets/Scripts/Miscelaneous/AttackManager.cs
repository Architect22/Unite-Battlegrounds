using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public PlayablePokemon activePokemon;
    public int enemyCount;
    public List<PlayablePokemon> EnemyPokemon = new List<PlayablePokemon>();
    [SerializeField] private HealthBar healthBar;
    private int attackDamage;

    private void Awake()
    {
        enemyCount = 1;
        attackDamage = 0;
    }

    public void DealDamage(float damage)
    {
        healthBar.DamageHealthbar(damage);
    }
}
