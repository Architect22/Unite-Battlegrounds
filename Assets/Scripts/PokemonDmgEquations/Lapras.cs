using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamageEquation", menuName = "Scriptable Objects/DamageEquations/Lapras")]
public class Lapras : BaseEquations
{
    private void Awake()
    {
        Move1Names = new List<string> { "Water Pulse", "Perish Song" };
        Move2Names = new List<string> { "Bubble Beam", "Ice Beam" };
        UltName = "Lapras Express";
    }
    public override void CalculateMove1Dmg(int index, bool enhanced)
    {
        usedMove1 = true;
        if (index == 0)
        {
            // water pulse
            totalDmg = (float)(0.74 * pokemon.attackStat) + (11 * (pokemon.level - 1)) + 230;
        }
        else
        {
            // perish song
            totalDmg = (float)(0.828 * pokemon.attackStat) + (9 * (pokemon.level - 1)) + 282;
        }
    }
    public override void CalculateMove2Dmg(int index, bool enhanced)
    {
        usedMove2 = true;
        if (index == 0)
        {
            // bubble beam
            totalDmg = (float)(1.19 * pokemon.attackStat) + (9 * (pokemon.level - 1)) + 400;
        }
        else
        {
            // ice beam
            totalDmg = (float)(0.36 * pokemon.attackStat) + (3 * (pokemon.level - 1)) + 120;
        }
    }
    public override void CalculateUltDmg()
    {
        usedUlt = true;
        // lapras express lol
        totalDmg = (float)(1.72 * pokemon.attackStat) + (12 * (pokemon.level - 1)) + 580;
    }
    public override void CalculateAttackStat()
    {
        switch (pokemon.level)
        {
            case 1:
                pokemon.attackStat = 90;
                break;
            case 2:
                pokemon.attackStat = 102;
                break;
            case 3:
                pokemon.attackStat = 115;
                break;
            case 4:
                pokemon.attackStat = 130;
                break;
            case 5:
                pokemon.attackStat = 146;
                break;
            case 6:
                pokemon.attackStat = 164;
                break;
            case 7:
                pokemon.attackStat = 183;
                break;
            case 8:
                pokemon.attackStat = 204;
                break;
            case 9:
                pokemon.attackStat = 228;
                break;
            case 10:
                pokemon.attackStat = 254;
                break;
            case 11:
                pokemon.attackStat = 283;
                break;
            case 12:
                pokemon.attackStat = 315;
                break;
            case 13:
                pokemon.attackStat = 350;
                break;
            case 14:
                pokemon.attackStat = 388;
                break;
            case 15:
                pokemon.attackStat = 430;
                break;
            default:
                pokemon.attackStat = 1;
                break;
        }
    }
}