using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTracker : MonoBehaviour
{
    [SerializeField] private Slider levelSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    public void OnSliderChanged()
    {
        levelText.text = levelSlider.value.ToString();
    }
}
