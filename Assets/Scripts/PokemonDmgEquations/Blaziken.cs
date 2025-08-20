using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamageEquation", menuName = "Scriptable Objects/DamageEquations/Blaziken")]
public class Blaziken : BaseEquations
{
    private void Awake()
    {
        Move1Names = new List<string> { "Fire Punch", "Focus Blast" };
        Move2Names = new List<string> { "Blaze Kick", "Overheat" };
        UltName = "Spinning Flame Fist";
    }
    public override void CalculateMove1Dmg(int index, bool enhanced)
    {
        usedMove1 = true;
        if (index == 0)
        {
            // fire punch
            totalDmg = (float)(0.63 * pokemon.attackStat) + (4 * (pokemon.level - 1)) + 114;
        }
        else
        {
            // blaze kick
            totalDmg = (float)(1.44 * pokemon.attackStat) + (7 * (pokemon.level - 1)) + 330;
        }
    }
    public override void CalculateMove2Dmg(int index, bool enhanced)
    {
        usedMove2 = true;
        if (index == 0)
        {
            // focus blast
            totalDmg = (float)(1.94 * pokemon.attackStat) + (10 * (pokemon.level - 1)) + 440;
        }
        else
        {
            // overheat
            if (enhanced)
            {
                totalDmg = (float)(4.385 * pokemon.attackStat) + (20 * (pokemon.level - 1)) + 818;
            }
            else
            {
                totalDmg = (float)(1.085 * pokemon.attackStat) + (6 * (pokemon.level - 1)) + 215;
            }
            
        }
    }
    public override void CalculateUltDmg()
    {
        usedUlt = true;
        // Spinning Flame Fist
        totalDmg = (float)(1 * pokemon.attackStat) + (7 * (pokemon.level - 1)) + 200;
    }
    public override void CalculateAttackStat()
    {
        switch (pokemon.level)
        {
            case 1:
                pokemon.attackStat = 160;
                break;
            case 2:
                pokemon.attackStat = 165;
                break;
            case 3:
                pokemon.attackStat = 171;
                break;
            case 4:
                pokemon.attackStat = 178;
                break;
            case 5:
                pokemon.attackStat = 203;
                break;
            case 6:
                pokemon.attackStat = 213;
                break;
            case 7:
                pokemon.attackStat = 258;
                break;
            case 8:
                pokemon.attackStat = 272;
                break;
            case 9:
                pokemon.attackStat = 289;
                break;
            case 10:
                pokemon.attackStat = 309;
                break;
            case 11:
                pokemon.attackStat = 333;
                break;
            case 12:
                pokemon.attackStat = 362;
                break;
            case 13:
                pokemon.attackStat = 397;
                break;
            case 14:
                pokemon.attackStat = 439;
                break;
            case 15:
                pokemon.attackStat = 490;
                break;
            default:
                pokemon.attackStat = 1;
                break;
        }
    }
    public override void ResetCooldowns()
    {
        usedMove1 = false;
        usedMove2 = false;
        usedUlt = false;
    }
}