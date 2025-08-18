using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerStats;
    [SerializeField] private GameObject cpuStats;
    [SerializeField] private Tweener playerTween;
    [SerializeField] private Tweener cpuTween;

    private bool isPlayerStatsShowing = true;
    private bool isCPUStatsShowing = true;

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
}
