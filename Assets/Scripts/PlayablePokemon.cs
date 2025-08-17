using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayablePokemon", menuName = "Scriptable Objects/PlayablePokemon")]
public class PlayablePokemon : ScriptableObject
{
    public String pokemonName = "";
    public List<Move> Move1Options;
    public List<Move> Move2Options;
    public Move Ult;
}
