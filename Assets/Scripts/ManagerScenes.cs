using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class ManagerScenes : MonoBehaviour
{
    public static ManagerScenes instance;
    [HideInInspector] public int LevelIndex;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void EndLevel()
    {
        if (!YG2.saves.OpenLevels.Contains(LevelIndex+1))
        {
            YG2.saves.OpenLevels.Add(LevelIndex+1);
            YG2.saves.score += 10;
            YG2.SetLeaderboard("LeaderBoard", YG2.saves.score);
            YG2.SaveProgress();
        }
        SceneManager.LoadScene("ChooseLevel");
    }
    public void BackMenu()
    {
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene("ChooseLevel");
    }
    public void NextLevel()
    {
        if (!YG2.saves.OpenLevels.Contains(LevelIndex + 1))
        {
            YG2.saves.OpenLevels.Add(LevelIndex + 1);
            YG2.saves.score += 10;
            YG2.SetLeaderboard("LeaderBoard", YG2.saves.score);
            YG2.SaveProgress();
        }
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene(LevelIndex+1);
    }
}
