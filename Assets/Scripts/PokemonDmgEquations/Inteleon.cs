using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamageEquation", menuName = "Scriptable Objects/DamageEquations/Inteleon")]
public class Inteleon : BaseEquations
{
    private void Awake()
    {
        Move1Names = new List<string> { "Fell Stinger", "Acrobatics" };
        Move2Names = new List<string> { "Snipe Shot", "Liquidation" };
        UltName = "Azure Spy Vision";
    }
    public override void CalculateMove1Dmg(int index, bool enhanced)
    {
        usedMove1 = true;
        if (index == 0)
        {
            // Fell Stinger
            totalDmg = (float)(0.63 * pokemon.attackStat) + (5 * (pokemon.level - 1)) + 200;
        }
        else
        {
            // Acrobatics
            totalDmg = (float)(0.62 * pokemon.attackStat) + (8 * (pokemon.level - 1)) + 172;
        }
    }
    public override void CalculateMove2Dmg(int index, bool enhanced)
    {
        usedMove2 = true;
        if (index == 0)
        {
            // Snipe Shot
            if (enhanced)
            {
                totalDmg = (float)(1.14 * pokemon.attackStat) + (10 * (pokemon.level - 1)) + 344;
            }
            else
            {
                totalDmg = (float)(0.58 * pokemon.attackStat) + (4 * (pokemon.level - 1)) + 172;
            }
            
        }
        else
        {
            // Liquidation
            totalDmg = (float)(0.142 * pokemon.attackStat) + (1 * (pokemon.level - 1)) + 44;
        }
    }
    public override void CalculateUltDmg()
    {
        usedUlt = true;
        // ult
        totalDmg = 0;
    }
    public override void CalculateAttackStat()
    {
        switch (pokemon.level)
        {
            case 1:
                pokemon.attackStat = 100;
                break;
            case 2:
                pokemon.attackStat = 111;
                break;
            case 3:
                pokemon.attackStat = 125;
                break;
            case 4:
                pokemon.attackStat = 142;
                break;
            case 5:
                pokemon.attackStat = 202;
                break;
            case 6:
                pokemon.attackStat = 226;
                break;
            case 7:
                pokemon.attackStat = 335;
                break;
            case 8:
                pokemon.attackStat = 369;
                break;
            case 9:
                pokemon.attackStat = 410;
                break;
            case 10:
                pokemon.attackStat = 459;
                break;
            case 11:
                pokemon.attackStat = 518;
                break;
            case 12:
                pokemon.attackStat = 589;
                break;
            case 13:
                pokemon.attackStat = 674;
                break;
            case 14:
                pokemon.attackStat = 777;
                break;
            case 15:
                pokemon.attackStat = 900;
                break;
            default:
                pokemon.attackStat = 1;
                break;
        }
    }
}