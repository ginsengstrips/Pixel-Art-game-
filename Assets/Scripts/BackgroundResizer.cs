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
        // Если окно изменило размер - обновляем камеру
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
        // Текущее соотношение сторон экрана
        float currentAspect = (float)Screen.width / Screen.height;

        // Если экран уже, чем целевое соотношение (например, 9:16)
        if (currentAspect < _targetAspectRatio)
        {
            // Увеличиваем orthographicSize, чтобы компенсировать узкий экран
            float scale = _targetAspectRatio / currentAspect;
            _camera.orthographicSize = _initialOrthoSize * scale;
        }
        else
        {
            // Возвращаем исходный размер (если экран шире)
            _camera.orthographicSize = _initialOrthoSize;
        }
    }
}
