using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private GameObject fillArea;
    [SerializeField] private Objective objective;
    [SerializeField] private CPUDamageBehavior cpu;
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private Slider objectiveHealthSlider;

    [Header("End Stats")]
    [SerializeField] private GameObject endStats;
    [SerializeField] private TextMeshProUGUI playerdamageTxt;
    [SerializeField] private TextMeshProUGUI objectiveHealthTxt;
    [SerializeField] private TextMeshProUGUI accuracyTxt;
    private bool isSecured = false;

    private void Start()
    {
        fillArea.SetActive(true);
        slider.maxValue = objective.health;
        slider.value = slider.maxValue;
        displayText.gameObject.SetActive(false);
        endStats.SetActive(false);
    }

    public void DamageHealthbar(float damage, string killSource)
    {
        float tempSliderValue = slider.value;
        float comparison = slider.value - damage;
        if (comparison <= 0 && !isSecured)
        {
            isSecured = true;
            cpu.ClearInvokes();
            double percentage = Math.Round((slider.value/damage) * 100, 2);
            slider.value = 0;
            fillArea.SetActive(false);
            DisplayEndStats(damage, tempSliderValue, (float)percentage);
            Debug.Log(killSource + " secured the objective!");
            displayText.gameObject.SetActive(true);
            displayText.text = killSource + " secured the objective!";
        }
        else
        {            
            slider.value -= damage;
        }
    }
    public void SetHealthBar(float amount)
    {
        if (amount <= slider.maxValue)
        {
            slider.value = amount;
        }
    }
    public void Reset()
    {
        isSecured = false;
        slider.value = objectiveHealthSlider.value;
        fillArea.SetActive(true);
        displayText.gameObject.SetActive(false);
        endStats.SetActive(false);
    }
    public void DisplayEndStats(float damage, float health, float accuracy)
    {
        endStats.SetActive(true);
        playerdamageTxt.text = damage.ToString();
        objectiveHealthTxt.text = health.ToString();
        accuracyTxt.text = accuracy.ToString()+"%";
    }
}
