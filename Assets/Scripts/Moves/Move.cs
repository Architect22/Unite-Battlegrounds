using UnityEngine;
[CreateAssetMenu(fileName = "PokemonMove", menuName = "Scriptable Objects/Move")]
public class Move : ScriptableObject
{
    public string AttackName = "";
    public float AttackDamage = 0;
    public float Cooldown = 1;
}