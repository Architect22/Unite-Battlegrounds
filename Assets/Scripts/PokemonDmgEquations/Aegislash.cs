using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamageEquation", menuName = "Scriptable Objects/DamageEquations/Aegislash")]
public class Aegislash : BaseEquations
{
    private void Awake()
    {
        Move1Names = new List<string> { "Sacred Sword", "Shadow Claw" };
        Move2Names = new List<string> { "Wide Guard", "Iron Head" };
        UltName = "Coup de Grace";
    }
    public override void CalculateMove1Dmg(int index, bool enhanced)
    {
        usedMove1 = true;
        if (index == 0)
        {
            // Sacred Sword
            totalDmg = (float)(0.96 * pokemon.attackStat) + (3 * (pokemon.level - 1)) + 120;
        }
        else
        {
            // shadow claw
            if (enhanced)
            {
                totalDmg = (float)(1.36 * pokemon.attackStat) + (6 * (pokemon.level - 1)) + 140;
            }
            else
            {                
                totalDmg = (float)(0.68 * pokemon.attackStat) + (3 * (pokemon.level - 1)) + 70;
            }
        }
    }
    public override void CalculateMove2Dmg(int index, bool enhanced)
    {
        usedMove2 = true;
        if (index == 0)
        {
            // wide guard
            totalDmg = 0;
        }
        else
        {
            // iron head
            totalDmg = (float)(1.18 * pokemon.attackStat) + (5 * (pokemon.level - 1)) + 130;
        }
    }
    public override void CalculateUltDmg()
    {
        usedUlt = true;
        // ult
        totalDmg = (float)(2.82 * pokemon.attackStat) + (13 * (pokemon.level - 1)) + 640;
        float executeAdd = 0.12f * (AttackManager.instance.GetMaxHealth() - AttackManager.instance.GetHealth());
        // it gets capped at 1000 for wilds
        if (executeAdd > 1000)
        {
            executeAdd = 1000;
        }
        totalDmg += executeAdd;
    }
    public override void CalculateAttackStat()
    {
        switch (pokemon.level)
        {
            case 1:
                pokemon.attackStat = 168;
                break;
            case 2:
                pokemon.attackStat = 171;
                break;
            case 3:
                pokemon.attackStat = 174;
                break;
            case 4:
                pokemon.attackStat = 178;
                break;
            case 5:
                pokemon.attackStat = 192;
                break;
            case 6:
                pokemon.attackStat = 198;
                break;
            case 7:
                pokemon.attackStat = 223;
                break;
            case 8:
                pokemon.attackStat = 231;
                break;
            case 9:
                pokemon.attackStat = 241;
                break;
            case 10:
                pokemon.attackStat = 253;
                break;
            case 11:
                pokemon.attackStat = 267;
                break;
            case 12:
                pokemon.attackStat = 284;
                break;
            case 13:
                pokemon.attackStat = 304;
                break;
            case 14:
                pokemon.attackStat = 328;
                break;
            case 15:
                pokemon.attackStat = 357;
                break;
            default:
                pokemon.attackStat = 1;
                break;
        }
        // this value because you will be in sword form \/
        pokemon.attackStat += 15 * (pokemon.level - 1) + 40;
    }
}