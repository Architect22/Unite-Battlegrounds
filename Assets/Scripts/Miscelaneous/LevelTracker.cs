using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTracker : MonoBehaviour
{
    [SerializeField] private Slider levelSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    public void OnLevelSliderChanged()
    {
        double number = Math.Round(levelSlider.value, 3);
        levelText.text = number.ToString();
        PokemonLookup.instance.activePokemon.level = (int)levelSlider.value;
    }

    public void OnSpeedSliderChanged()
    {
        double number = Math.Round(levelSlider.value, 3);
        levelText.text = number.ToString();
    }

    public void OnDamageSliderChanged()
    {
        double number = Math.Round(levelSlider.value, 2);
        levelText.text = number.ToString();
    }
}
