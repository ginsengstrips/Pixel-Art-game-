using UnityEngine;
using YG;
public class RewardManager : MonoBehaviour
{
    [SerializeField] private GameObject _rewardCanvas;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject[] _otherCanvasElements;
    public void OpenReward()
    {
        _rewardCanvas.SetActive(true);
    }
    public void CloseReward()
    {
        _rewardCanvas.SetActive(false);
    }
    public void RewardShow()
    {
        YG2.RewardedAdvShow("level", Reward);
    }
    public void Reward()
    {
        
        YG2.saves.OpenLevels.Add(ManagerScenes.instance.LevelIndex + 1);
        YG2.SaveProgress();
        _nextButton.SetActive(true);
        for (int i = 0; i < _otherCanvasElements.Length; i++)
            _otherCanvasElements[i].SetActive(false);
    }
}
