using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayablePokemon", menuName = "Scriptable Objects/PlayablePokemon")]
public class PlayablePokemon : ScriptableObject
{
    public string pokemonName = "";
    public int level = 1;
    public float attackStat = 1;
    public BaseEquations dmgEquations;
}
