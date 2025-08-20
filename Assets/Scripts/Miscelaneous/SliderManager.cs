using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Slider levelSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Slider speedSlider;
    [SerializeField] private TextMeshProUGUI speedText;

    [SerializeField] private Slider damageSlider;
    [SerializeField] private TextMeshProUGUI damageText;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private Slider secureSlider;
    [SerializeField] private TextMeshProUGUI secureText;

    private void Start()
    {
        // make sure the text accurately reflects the slider settings on startup
        double number = Math.Round(levelSlider.value, 2);
        levelText.text = number.ToString();
        OnSpeedSliderChanged();
        OnDamageSliderChanged();
        number = Math.Round(healthSlider.value, 2);
        healthText.text = number.ToString();
        OnSecureSliderChanged();
    }

    public void OnLevelSliderChanged()
    {
        double number = Math.Round(levelSlider.value, 2);
        levelText.text = number.ToString();
        PokemonLookup.instance.activePokemon.level = (int)levelSlider.value;
    }

    public void OnSpeedSliderChanged()
    {
        double number = Math.Round(speedSlider.value, 3);
        speedText.text = number.ToString();
    }

    public void OnDamageSliderChanged()
    {
        double number = Math.Round(damageSlider.value, 2);
        damageText.text = number.ToString();
    }

    public void OnHealthSliderChanged()
    {
        double number = Math.Round(healthSlider.value, 2);
        healthText.text = number.ToString();
        AttackManager.instance.SetDamage(float.Parse(healthText.text));
    }

    public void OnSecureSliderChanged()
    {
        double number = Math.Round(secureSlider.value, 0);
        secureText.text = number.ToString();
        CPUDamageBehavior.instance.CPUSecureValue = (float)number;
    }
}
