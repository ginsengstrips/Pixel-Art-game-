using UnityEngine;

public class CellInfo : MonoBehaviour
{
    private Color32 _neededColor; // The required cell color to obtain the correct pattern is set before the scene starts
    private Color32 _defaultColor = new Color32(255, 255, 255, 7); // Standard uncolored color
    private bool _neededColorWasInstalled; // Is the correct color set

    private void Awake()
    {
        _neededColor = GetComponent<SpriteRenderer>().color; 
        GetComponent<SpriteRenderer>().color = _defaultColor; // Change the color from the required one to the uncolored
    }
    private void OnMouseDown()
    {
        ClickCell(); // Performing coloring with a single mouse click
    }
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            ClickCell(); // Performing coloring by holding down the mouse button
        }
    }
    private void ClickCell()
    {
        SoundManager.instance.PaintingSound(); // Playing the coloring sound

        Color activeColor = Coloring.instance.ActiveColor; // Selected fill color
        if (activeColor == _neededColor && !_neededColorWasInstalled) 
        {
            Coloring.instance.CorrectColoring(); // If the selected color matches the required cell color and the required color was not set,
                                                 // increase the count of correctly colored cells
            _neededColorWasInstalled = true;
        }
        else if (activeColor != _neededColor && _neededColorWasInstalled)
        {
            Coloring.instance.UnCorrectColoring(); // If the selected color does not match the required cell color and the required color was set,
                                                   // decrease the count of correctly colored cells

            _neededColorWasInstalled = false;
        }
        GetComponent<SpriteRenderer>().color = activeColor; // Change the cell color
        //Debug.Log("_neededColor " + _neededColor);
    }
}
