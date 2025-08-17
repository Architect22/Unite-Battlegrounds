using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private GameObject fillArea;
    [SerializeField] private Objective objective;

    private void Start()
    {
        fillArea.SetActive(true);
        slider.maxValue = objective.health;
        slider.value = slider.maxValue;
    }

    public void DamageHealthbar(float damage)
    {
        slider.value -= damage;
        if (slider.value - damage <= 0)
        {
            slider.value = 0;
            fillArea.SetActive(false);
        }
    }
}
