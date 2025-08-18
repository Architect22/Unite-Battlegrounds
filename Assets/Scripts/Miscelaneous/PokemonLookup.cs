using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokemonLookup : MonoBehaviour
{
    public static PokemonLookup instance;

    [Header("References")]
    [SerializeField] private TMP_Dropdown SelectedPokemonDropdown;
    public TMP_Dropdown Move1Dropdown;
    public TMP_Dropdown Move2Dropdown;
    [SerializeField] private TextMeshProUGUI Move1;
    [SerializeField] private TextMeshProUGUI Move2;
    [SerializeField] private TextMeshProUGUI Ult;

    public List<PlayablePokemon> playablePokemon;
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
            List<string> selectedOptions = new List<string>{ pokemon.pokemonName };
            SelectedPokemonDropdown.AddOptions(selectedOptions);
        }
        UpdateMoveUI();
    }

    public void UpdateMoveUI()
    {
        int selectedIndex = SelectedPokemonDropdown.value;
        string pokemon = SelectedPokemonDropdown.options[selectedIndex].text;
        activePokemon = PokemonList[pokemon];
        UpdateMoveDropdownUI(PokemonList[pokemon]);
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
}
