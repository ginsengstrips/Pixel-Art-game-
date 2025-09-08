using UnityEngine;
public class Coloring : MonoBehaviour
{
    public static Coloring instance;
    [SerializeField] private int _maxCorrectValue; // Maximum required number of correctly colored cells (total number of cells in the pattern)
    [SerializeField] private GameObject _particleSystem; // Level completion effect
    public Color32 ActiveColor; // Selected color
    private int _correctColors; // Number of correctly colored cells
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public void CorrectColoring()
    {
        _correctColors++;
        Debug.Log("_correctColors" + _correctColors);
        if (_correctColors == _maxCorrectValue) 
        {
            Instantiate(_particleSystem, transform.position, _particleSystem.transform.rotation);
            SoundManager.instance.XpSound();
            Invoke(nameof(EndLevel), 3.2f);
        }
    }
    public void UnCorrectColoring()
    {
        _correctColors--;
        //Debug.Log("_correctColors" + _correctColors);
    }
    public void ChangeColor(Color color)
    {
        ActiveColor = color; // Active color change
        //Debug.Log("ActiveColor" + ActiveColor);
    }
    private void EndLevel()
    {
        ManagerScenes.instance.EndLevel();
    }
}
