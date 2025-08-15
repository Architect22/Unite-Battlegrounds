using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayablePokemon", menuName = "Scriptable Objects/PlayablePokemon")]
public class PlayablePokemon : ScriptableObject
{
    public List<Move> moves;

}
