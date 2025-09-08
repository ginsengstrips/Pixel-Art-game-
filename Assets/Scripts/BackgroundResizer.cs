using UnityEngine;

public class BackgroundResizer: MonoBehaviour
{
    public Vector2 targetAspect = new Vector2(16, 9);

    private Camera _camera;
    private float _initialOrthoSize;
    private float _targetAspectRatio;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _initialOrthoSize = _camera.orthographicSize;
        _targetAspectRatio = targetAspect.x / targetAspect.y;

        UpdateCamera();
    }
    private void Update()
    {
        // ���� ���� �������� ������ - ��������� ������
        if (Screen.width != _lastWidth || Screen.height != _lastHeight)
        {
            UpdateCamera();
            _lastWidth = Screen.width;
            _lastHeight = Screen.height;
        }
    }
    private int _lastWidth, _lastHeight;
    private void UpdateCamera()
    {
        // ������� ����������� ������ ������
        float currentAspect = (float)Screen.width / Screen.height;

        // ���� ����� ���, ��� ������� ����������� (��������, 9:16)
        if (currentAspect < _targetAspectRatio)
        {
            // ����������� orthographicSize, ����� �������������� ����� �����
            float scale = _targetAspectRatio / currentAspect;
            _camera.orthographicSize = _initialOrthoSize * scale;
        }
        else
        {
            // ���������� �������� ������ (���� ����� ����)
            _camera.orthographicSize = _initialOrthoSize;
        }
    }
}
