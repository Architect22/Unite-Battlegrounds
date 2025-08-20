using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Toggle enhancedMove1;
    [SerializeField] private Toggle enhancedMove2;
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
    public void SetDamage(float amount)
    {
        healthBar.SetHealthBar(amount);
    }
    public float GetHealth()
    {
        return healthBar.slider.value;
    }
    public float GetMaxHealth()
    {
        return healthBar.slider.maxValue;
    }
    public void UseMove1()
    {
        if (!PokemonLookup.instance.activePokemon.dmgEquations.usedMove1)
        {
            PokemonLookup.instance.activePokemon.dmgEquations.CalculateAttackStat();
            PokemonLookup.instance.activePokemon.dmgEquations.CalculateMove1Dmg(PokemonLookup.instance.Move1Dropdown.value, enhancedMove1.isOn);
            DealDamage(PokemonLookup.instance.activePokemon.dmgEquations.totalDmg, PokemonLookup.instance.Move1Dropdown.options[PokemonLookup.instance.Move1Dropdown.value].text);
            UIManager.instance.move1Btn.interactable = false;
        }
    }
    public void UseMove2()
    {
        if (!PokemonLookup.instance.activePokemon.dmgEquations.usedMove2)
        {
            PokemonLookup.instance.activePokemon.dmgEquations.CalculateAttackStat();
            PokemonLookup.instance.activePokemon.dmgEquations.CalculateMove2Dmg(PokemonLookup.instance.Move2Dropdown.value, enhancedMove2.isOn);
            DealDamage(PokemonLookup.instance.activePokemon.dmgEquations.totalDmg, PokemonLookup.instance.Move2Dropdown.options[PokemonLookup.instance.Move2Dropdown.value].text);
            UIManager.instance.move2Btn.interactable = false;
        }
    }
    public void UseUlt()
    {
        if (!PokemonLookup.instance.activePokemon.dmgEquations.usedUlt)
        {
            PokemonLookup.instance.activePokemon.dmgEquations.CalculateAttackStat();
            PokemonLookup.instance.activePokemon.dmgEquations.CalculateUltDmg();
            DealDamage(PokemonLookup.instance.activePokemon.dmgEquations.totalDmg, PokemonLookup.instance.activePokemon.dmgEquations.UltName);
            UIManager.instance.ultBtn.interactable = false;
        }
    }
    public void ResetObjective()
    {
        healthBar.Reset();
        PokemonLookup.instance.activePokemon.dmgEquations.ResetCooldowns();
        UIManager.instance.move1Btn.interactable = true;
        UIManager.instance.move2Btn.interactable = true;
        UIManager.instance.ultBtn.interactable = true;
    }
}
