using UnityEngine;
using UnityEngine.SceneManagement;

public class BlocksSelector : MonoBehaviour
{
    public static BlocksSelector instance;
    private string _selectedBlock;
    private int _indexBlock = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetBlock(); // Ваш метод
    }
    public void SelectBlock(string block)
    {
        _selectedBlock = block;
        Debug.Log("_selectedBlock " + _selectedBlock);
    }
    public void SelectIndex(int index)
    {
        _indexBlock = index;
    }
    private void SetBlock()
    {
        if(SceneManager.GetActiveScene().name == "ChooseLevel")
        {
            StartManager.instance.SelectBlock(_selectedBlock, _indexBlock);
        }
    }
}
