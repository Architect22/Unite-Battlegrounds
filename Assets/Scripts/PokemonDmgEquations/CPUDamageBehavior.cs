using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CPUDamageBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown CpuDmgBehaviorDropdown;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private Toggle secureToggle;
    public float CPUSecureValue { get; set; }
    public bool CanAttemptSecure { get; set; }

    private float tickTimer = 0.5f;
    private bool isDealingDamage = false;

    public static CPUDamageBehavior instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (CanAttemptSecure && isDealingDamage && AttackManager.instance.GetHealth() <= CPUSecureValue)
        {
            Secure();
        }
    }

    public void CPUDamageTick()
    {
        tickTimer = float.Parse(speed.text);
        isDealingDamage = true;
        int index = CpuDmgBehaviorDropdown.value;
        switch (index)
        {
            case 0:
                InvokeRepeating(nameof(LinearDamage), 0, tickTimer);
                break;
            case 1:
                InvokeRepeating(nameof(LinearRandBurstDamage), 0, tickTimer);
                break;
            case 2:
                InvokeRepeating(nameof(PredictRandBurstDamage), 0, tickTimer);
                break;
            case 3:
                InvokeRepeating(nameof(UnpredictRandBurstDamage), 0, tickTimer);
                break;
            case 4:
                InvokeRepeating(nameof(RandLargeBurstDamage), 0, tickTimer);
                break;
            case 5:
                InvokeRepeating(nameof(RandSmallBurstDamage), 0, tickTimer);
                break;
            default:
                break;
        }
    }
    public void ClearInvokes()
    {
        CancelInvoke();
        isDealingDamage = false;
    }

    public void LinearDamage()
    {
        AttackManager.instance.DealDamage(float.Parse(damage.text), "CPU");
    }
    public void LinearRandBurstDamage()
    {
        float randomDamage = Random.Range(0, 100);
        AttackManager.instance.DealDamage(float.Parse(damage.text) + randomDamage, "CPU");
    }
    public void PredictRandBurstDamage()
    {
        float randomDamage = Random.Range(0, 100);
        AttackManager.instance.DealDamage(randomDamage, "CPU");
    }
    public void UnpredictRandBurstDamage()
    {

    }
    public void RandLargeBurstDamage()
    {
        float randomDamage = Random.Range(100, 300);
        AttackManager.instance.DealDamage(randomDamage, "CPU");
    }
    public void RandSmallBurstDamage()
    {
        float randomDamage = Random.Range(10, 150);
        AttackManager.instance.DealDamage(randomDamage, "CPU");
    }

    public void OnBehaviorChangedWhileLive()
    {
        if (isDealingDamage)
        {
            ClearInvokes();
            CPUDamageTick();
        }
    }

    public void Secure()
    {
        AttackManager.instance.DealDamage(AttackManager.instance.GetHealth(), "CPU Secure");
    }

    public void SetCanSecure()
    {
        CanAttemptSecure = secureToggle.isOn;
    }
}
