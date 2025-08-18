using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    public static AttackManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DealDamage(float damage, string killSource)
    {
        healthBar.DamageHealthbar(damage, killSource);
    }
    public void UseMove1()
    {
        PokemonLookup.instance.activePokemon.dmgEquations.CalculateAttackStat();
        PokemonLookup.instance.activePokemon.dmgEquations.CalculateMove1Dmg(PokemonLookup.instance.Move1Dropdown.value);
        DealDamage(PokemonLookup.instance.activePokemon.dmgEquations.totalDmg, PokemonLookup.instance.Move1Dropdown.options[PokemonLookup.instance.Move1Dropdown.value].text);
    }
    public void UseMove2()
    {
        PokemonLookup.instance.activePokemon.dmgEquations.CalculateAttackStat();
        PokemonLookup.instance.activePokemon.dmgEquations.CalculateMove2Dmg(PokemonLookup.instance.Move2Dropdown.value);
        DealDamage(PokemonLookup.instance.activePokemon.dmgEquations.totalDmg,PokemonLookup.instance.Move2Dropdown.options[PokemonLookup.instance.Move2Dropdown.value].text);
    }
    public void UseUlt()
    {
        PokemonLookup.instance.activePokemon.dmgEquations.CalculateAttackStat();
        PokemonLookup.instance.activePokemon.dmgEquations.CalculateUltDmg();
        DealDamage(PokemonLookup.instance.activePokemon.dmgEquations.totalDmg,PokemonLookup.instance.activePokemon.dmgEquations.UltName);
    }
    public void ResetObjective()
    {
        healthBar.Reset();
    }
}
