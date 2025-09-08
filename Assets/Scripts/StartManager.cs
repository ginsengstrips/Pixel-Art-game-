using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;
public class StartManager : MonoBehaviour
{
    public static StartManager instance;
    [SerializeField] private GameObject _chooseLevelMenu;

    [SerializeField] private GameObject _standartCanvas;
    [SerializeField] private TextMeshProUGUI _standartProgress;
    [SerializeField] private GameObject[] _standartBlocks;
    
    [SerializeField] private GameObject _youtubersCanvas;
    [SerializeField] private GameObject[] _youtubersBlocks;
    [SerializeField] private TextMeshProUGUI _youtubersProgress;

    [SerializeField] private GameObject _otherCanvas;
    [SerializeField] private GameObject[] _otherBlocks;
    [SerializeField] private TextMeshProUGUI _otherProgress;

    [SerializeField] private GameObject _fnafCanvas;
    [SerializeField] private GameObject[] _fnafBlocks;
    [SerializeField] private TextMeshProUGUI _fnafProgress;

    private int _indexBlock = 0;
    private int _standartDone = 0;
    private int _youtubersDone = 0;
    private int _otherDone = 0;
    private int _fnafDone = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        ProgressLevels();
    }
    public void LoadLevel(string levelName)
    {
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene(levelName);
    }
    public void NextBlock(string typeBlock)
    {
        switch (typeBlock)
        {
            case "Standart":
                _standartBlocks[_indexBlock].SetActive(false);
                _indexBlock++;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _standartBlocks[_indexBlock].SetActive(true);
                break;
            case "Youtubers":
                _youtubersBlocks[_indexBlock].SetActive(false);
                _indexBlock++;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _youtubersBlocks[_indexBlock].SetActive(true);
                break;
            case "Other":
                _otherBlocks[_indexBlock].SetActive(false);
                _indexBlock++;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _otherBlocks[_indexBlock].SetActive(true);
                break;
            case "Fnaf":
                _fnafBlocks[_indexBlock].SetActive(false);
                _indexBlock++;
                _fnafBlocks[_indexBlock].SetActive(true);
                break;
        }
    }
    public void PreviousBlock(string typeBlock)
    {
        switch (typeBlock)
        {
            case "Standart":
                _standartBlocks[_indexBlock].SetActive(false);
                _indexBlock--;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _standartBlocks[_indexBlock].SetActive(true);
                break;
            case "Youtubers":
                _youtubersBlocks[_indexBlock].SetActive(false);
                _indexBlock--;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _youtubersBlocks[_indexBlock].SetActive(true);
                break;
            case "Other":
                _otherBlocks[_indexBlock].SetActive(false);
                _indexBlock--;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _otherBlocks[_indexBlock].SetActive(true);
                break;
            case "Fnaf":
                _fnafBlocks[_indexBlock].SetActive(false);
                _indexBlock--;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _fnafBlocks[_indexBlock].SetActive(true);
                break;
        }
    }
    public void ChooseBlock(string typeBlock)
    {
        switch (typeBlock)
        {
            case "Standart":
                BlocksSelector.instance.SelectBlock(typeBlock);
                _indexBlock = 0;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _standartBlocks[_indexBlock].SetActive(true);
                _standartCanvas.SetActive(true);
                _chooseLevelMenu.SetActive(false);
                break;
            case "Youtubers":
                BlocksSelector.instance.SelectBlock(typeBlock);
                _indexBlock = 0;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _youtubersBlocks[_indexBlock].SetActive(true);
                _youtubersCanvas.SetActive(true);
                _chooseLevelMenu.SetActive(false);
                break;
            case "Other":
                BlocksSelector.instance.SelectBlock(typeBlock);
                _otherCanvas.SetActive(true);
                _indexBlock = 0;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _otherBlocks[_indexBlock].SetActive(true);
                _chooseLevelMenu.SetActive(false);
                break;
            case "Fnaf":
                BlocksSelector.instance.SelectBlock(typeBlock);
                _fnafCanvas.SetActive(true);
                _indexBlock = 0;
                BlocksSelector.instance.SelectIndex(_indexBlock);
                _chooseLevelMenu.SetActive(false);
                break;
        }
    }
    public void BackMenuLevel(string typeBlock)
    {
        switch (typeBlock)
        {
            case "Standart":
                _standartCanvas.SetActive(false);
                _chooseLevelMenu.SetActive(true);
                _standartBlocks[1].SetActive(false);
                _indexBlock = 0;
                break;
            case "Youtubers":
                _youtubersCanvas.SetActive(false);
                _chooseLevelMenu.SetActive(true);
                _youtubersBlocks[1].SetActive(false);
                _indexBlock = 0;
                break;
            case "Other":
                _otherCanvas.SetActive(false);
                _chooseLevelMenu.SetActive(true);
                _otherBlocks[1].SetActive(false);
                break;
            case "Fnaf":
                _fnafCanvas.SetActive(false);
                _chooseLevelMenu.SetActive(true);
                _indexBlock = 0;
                break;
        }
    }
    public void SelectBlock(string blockName, int indexBlock)
    {
        switch (blockName)
        {
            case "Standart":
                _chooseLevelMenu.SetActive(false);
                _standartCanvas.SetActive(true);
                _standartBlocks[indexBlock].SetActive(true);
                break;
            case "Youtubers":
                _chooseLevelMenu.SetActive(false);
                _youtubersCanvas.SetActive(true);
                _youtubersBlocks[indexBlock].SetActive(true);
                break;
            case "Other":
                _chooseLevelMenu.SetActive(false);
                _otherCanvas.SetActive(true);
                _otherBlocks[indexBlock].SetActive(true);
                break;
            case "Fnaf":
                _chooseLevelMenu.SetActive(false);
                _fnafCanvas.SetActive(true);
                break;
        }
    }
    private void ProgressLevels()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "StartScene")
            return;
        List<int> progressLevels = YG2.saves.OpenLevels;
        for(int i=0; i < progressLevels.Count; i++)
        {
            if (progressLevels[i] <= 20)
            {
                _standartDone++;
                _standartProgress.text = _standartDone.ToString() +"/20";
            }
            else if(progressLevels[i] > 20 &&progressLevels[i] <= 40)
            {
                _youtubersDone++;
                _youtubersProgress.text = _youtubersDone.ToString() + "/20";
            }
            else if(progressLevels[i] >40 && progressLevels[i] <= 60)
            {
                _otherDone++;
                _otherProgress.text = _otherDone.ToString() + "/20";
            }
            else if(progressLevels[i] > 60 && progressLevels[i] <= 70)
            {
                _fnafDone++;
                _fnafProgress.text = _otherDone.ToString() + "/10";
            }
        }
    }
}
