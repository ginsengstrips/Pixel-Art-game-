using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color32 _activeColor;
    [SerializeField] private GameObject _ramkaObject;
    private void Awake()
    {
        _activeColor = GetComponent<SpriteRenderer>().color;
    }
    private void OnMouseDown()
    {
        Coloring.instance.ChangeColor(_activeColor);
        SoundManager.instance.ClickSound();
        _ramkaObject.transform.position = transform.position;
    }
}
