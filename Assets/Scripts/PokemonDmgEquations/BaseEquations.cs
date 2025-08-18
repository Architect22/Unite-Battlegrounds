using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageEquation", menuName = "Scriptable Objects/DamageEquations")]
public class BaseEquations : ScriptableObject
{
    [HideInInspector] public float totalDmg = 0;
    public List<string> Move1Names;
    public List<string> Move2Names;
    public bool usedMove1 = false;
    public bool usedMove2 = false;
    public bool usedUlt = false;
    public string UltName;
    public PlayablePokemon pokemon;
    public virtual void CalculateMove1Dmg(int index)
    {

    }
    public virtual void CalculateMove2Dmg(int index)
    {

    }
    public virtual void CalculateUltDmg()
    {

    }
    public virtual void CalculateAttackStat()
    {

    }
    public virtual void ResetCooldowns()
    {
        
    }
}