using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamageEquation", menuName = "Scriptable Objects/DamageEquations/Urshifu")]
public class Urshifu : BaseEquations
{
    private void Awake()
    {
        Move1Names = new List<string> { "Wicked Blow", "Surging Strikes" };
        Move2Names = new List<string> { "Throat Chop", "Liquidation" };
        UltName = "Ebon Fist";
    }
    public override void CalculateMove1Dmg(int index, bool enhanced)
    {
        usedMove1 = true;
        if (index == 0)
        {
            // Wicked blow
            if (enhanced)
            {
                totalDmg = (float)(1.75 * pokemon.attackStat) + (12 * (pokemon.level - 1)) + 280;
                totalDmg *= 2; // because this hit is always a critical
                float executeAdd = 0.1f * (AttackManager.instance.GetMaxHealth() - AttackManager.instance.GetHealth());
                if (executeAdd > 1200)
                {
                    executeAdd = 1200;
                }
                totalDmg += executeAdd;
            }
            else
            {
                totalDmg = (float)(1.10 * pokemon.attackStat) + (7 * (pokemon.level - 1)) + 175;
            }
            
        }
        else
        {
            // Surging strikes
            totalDmg = (float)(0.902 * pokemon.attackStat) + (4 * (pokemon.level - 1)) + 125;
        }
    }
    public override void CalculateMove2Dmg(int index, bool enhanced)
    {
        usedMove2 = true;
        if (index == 0)
        {
            // throat chop
            totalDmg = (float)(1.79 * pokemon.attackStat) + (6 * (pokemon.level - 1)) + 340;
        }
        else
        {
            // liquidation            
            totalDmg = (float)(0.975 * pokemon.attackStat) + (6 * (pokemon.level - 1)) + 165;
            
        }
    }
    public override void CalculateUltDmg()
    {
        usedUlt = true;
        // Ebon Fist
        totalDmg = 0; // can't use on an objective
    }
    public override void CalculateAttackStat()
    {
        switch (pokemon.level)
        {
            case 1:
                pokemon.attackStat = 150;
                break;
            case 2:
                pokemon.attackStat = 157;
                break;
            case 3:
                pokemon.attackStat = 165;
                break;
            case 4:
                pokemon.attackStat = 175;
                break;
            case 5:
                pokemon.attackStat = 219;
                break;
            case 6:
                pokemon.attackStat = 232;
                break;
            case 7:
                pokemon.attackStat = 247;
                break;
            case 8:
                pokemon.attackStat = 264;
                break;
            case 9:
                pokemon.attackStat = 284;
                break;
            case 10:
                pokemon.attackStat = 306;
                break;
            case 11:
                pokemon.attackStat = 332;
                break;
            case 12:
                pokemon.attackStat = 362;
                break;
            case 13:
                pokemon.attackStat = 396;
                break;
            case 14:
                pokemon.attackStat = 435;
                break;
            case 15:
                pokemon.attackStat = 480;
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