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
    private bool isSecured = false;

    private void Start()
    {
        fillArea.SetActive(true);
        slider.maxValue = objective.health;
        slider.value = slider.maxValue;
        displayText.gameObject.SetActive(false);
    }

    public void DamageHealthbar(float damage, string killSource)
    {
        slider.value -= damage;
        if (slider.value - damage <= 0 && !isSecured)
        {
            isSecured = true;
            cpu.ClearInvokes();
            slider.value = 0;
            fillArea.SetActive(false);
            Debug.Log(killSource + " secured the objective!");
            displayText.gameObject.SetActive(true);
            displayText.text = killSource + " secured the objective!";
        }
    }
    public void Reset()
    {
        isSecured = false;
        slider.value = slider.maxValue;
        fillArea.SetActive(true); 
        displayText.gameObject.SetActive(false);
    }
}
