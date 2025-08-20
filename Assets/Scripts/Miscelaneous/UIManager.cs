using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerStats;
    [SerializeField] private GameObject cpuStats;
    [SerializeField] private Tweener playerTween;
    [SerializeField] private Tweener cpuTween;
    [SerializeField] private Tweener buffsTween;
    public Button move1Btn;
    public Button move2Btn;
    public Button ultBtn;

    public static UIManager instance;

    private bool isPlayerStatsShowing = true;
    private bool isCPUStatsShowing = true;
    private bool isBuffsStatsShowing = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnPlayerBtnPressed()
    {
        if (isPlayerStatsShowing && !playerTween.isAnimating)
        {
            playerTween.Move(-1, false);
        }
        else
        {
            playerTween.Move(1, false);
        }
        isPlayerStatsShowing = !isPlayerStatsShowing;
    }
    public void OnCpuBtnPressed()
    {
        if (isCPUStatsShowing && !cpuTween.isAnimating)
        {
            cpuTween.Move(1, false);
        }
        else
        {
            cpuTween.Move(-1, false);
        }
        isCPUStatsShowing = !isCPUStatsShowing;
    }
    public void OnBuffsBtnPressed()
    {
        if (isBuffsStatsShowing && !buffsTween.isAnimating)
        {
            buffsTween.Move(-1, false);
        }
        else
        {
            buffsTween.Move(1, false);
        }
        isBuffsStatsShowing = !isBuffsStatsShowing;
    }
}
