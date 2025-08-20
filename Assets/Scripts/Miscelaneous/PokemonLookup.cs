using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokemonLookup : MonoBehaviour
{
    public static PokemonLookup instance;

    [Header("References")]
    [SerializeField] private TMP_Dropdown SelectedPokemonDropdown;
    [SerializeField] private TMP_Dropdown heldItem1;
    [SerializeField] private TMP_Dropdown heldItem2;
    [SerializeField] private TMP_Dropdown heldItem3;
    public TMP_Dropdown Move1Dropdown;
    public TMP_Dropdown Move2Dropdown;
    [SerializeField] private TextMeshProUGUI Move1;
    [SerializeField] private TextMeshProUGUI Move2;
    [SerializeField] private TextMeshProUGUI Ult;
    [SerializeField] private SpriteRenderer activePokemonSprite;

    public List<PlayablePokemon> playablePokemon;
    public List<Item> heldItems;
    public Dictionary<string, PlayablePokemon> PokemonList = new Dictionary<string, PlayablePokemon>();

    [HideInInspector] public PlayablePokemon activePokemon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        // initialize the pokemon dictionary and populate the pokemon selector dropdown
        foreach (var pokemon in playablePokemon)
        {
            PokemonList.Add(pokemon.pokemonName, pokemon);
            List<string> selectedOptions = new List<string> { pokemon.pokemonName };
            SelectedPokemonDropdown.AddOptions(selectedOptions);
        }
        foreach (var item in heldItems)
        {
            List<string> itemOptions = new List<string> { item.itemName };
            heldItem1.AddOptions(itemOptions);
            heldItem2.AddOptions(itemOptions);
            heldItem3.AddOptions(itemOptions);
        }
        UpdateMoveUI();
    }

    public void UpdateMoveUI()
    {
        int selectedIndex = SelectedPokemonDropdown.value;
        string pokemon = SelectedPokemonDropdown.options[selectedIndex].text;
        activePokemon = PokemonList[pokemon];
        UpdateMoveDropdownUI(PokemonList[pokemon]);
        UpdatePokemonSprite();
        activePokemon.dmgEquations.ResetCooldowns();
    }

    private void UpdateMoveDropdownUI(PlayablePokemon pokemon)
    {
        Move1Dropdown.options[0].text = pokemon.dmgEquations.Move1Names[0];
        Move1Dropdown.options[1].text = pokemon.dmgEquations.Move1Names[1];
        Move1Dropdown.RefreshShownValue();

        Move2Dropdown.options[0].text = pokemon.dmgEquations.Move2Names[0];
        Move2Dropdown.options[1].text = pokemon.dmgEquations.Move2Names[1];
        Move2Dropdown.RefreshShownValue();
        UpdateMoveButtonUI();
    }

    public void UpdateMoveButtonUI()
    {
        Move1.text = Move1Dropdown.options[Move1Dropdown.value].text;
        Move2.text = Move2Dropdown.options[Move2Dropdown.value].text;
        Ult.text = activePokemon.dmgEquations.UltName;
    }

    public void UpdatePokemonSprite()
    {
        activePokemonSprite.sprite = activePokemon.pokemonSprite;
    }
}
