using UnityEngine;
using YG;
using UnityEngine.UI;
public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private int _indexLevel;
    private bool _locked = true;
    private void Start()
    {
        LockedLevel();
    }
    public void LoadLevel()
    {
        if (!_locked)
            StartManager.instance.LoadLevel(_levelName);
    }
    private void LockedLevel()
    {
        if (YG2.saves.OpenLevels.Contains(_indexLevel))
            _locked = false;
        else
        {
            GetComponent<Image>().color = Color.gray;
        }
    }
}
