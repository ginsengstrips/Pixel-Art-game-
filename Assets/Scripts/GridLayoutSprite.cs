using System.Collections.Generic;
using UnityEngine;

public class GridLayoutSprite : MonoBehaviour
{
    [SerializeField] private GameObject[] _rows;
    private SpriteRenderer[] _sprites; // 
    [SerializeField] private int _columns = 8;          // amount columns
    [SerializeField] private float _spacingX = 0.5f;      // distance by X
    [SerializeField] private float _spacingY = 0.5f;      // distance by Y

    [ContextMenu("Distribute in Grid")]

    private void Start()
    {
        List<SpriteRenderer> spriteList = new List<SpriteRenderer>();
        for (int i = 0; i < _rows.Length; i++)
        {
            spriteList.AddRange(_rows[i].GetComponentsInChildren<SpriteRenderer>());
        }
        _sprites = spriteList.ToArray();
        DistributeInGrid();
    }
    public void DistributeInGrid()
    {
        if (_sprites == null || _sprites.Length == 0)
        {
            return;
        }
        Vector3 startPos = _sprites[0].transform.position;
        for (int i = 0; i < _sprites.Length; i++)
        {
            int row = i / _columns;
            int col = i % _columns;

            float posX = startPos.x + col * _spacingX;
            float posY = startPos.y - row * _spacingY; 

            _sprites[i].transform.position = new Vector3(posX, posY, startPos.z);
        }
    }
}
