using UnityEngine;
using UnityEngine.UI;
public class Move
{
    public string AttackName = "";
    public float AttackDamage = 0;
    public float Cooldown = 1;
    [SerializeField] private Dropdown moveDropdown;
}