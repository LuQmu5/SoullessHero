using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundFollower : MonoBehaviour
{
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private Transform _followTarget;

    private RawImage _background;
    private float _offsetX;
    private float _lastPositionX;

    private void Start()
    {
        _background = GetComponent<RawImage>();
        _lastPositionX = _followTarget.position.x;
    }

    private void Update()
    {
        if (_lastPositionX == _followTarget.position.x)
            return;

        var direction = _lastPositionX < _followTarget.position.x ? 1 : -1;
        _lastPositionX = _followTarget.position.x;

        _offsetX += Time.deltaTime * _speed * direction;

        if (_offsetX >= 1)
        {
            _offsetX = 0;
        }

        _background.uvRect = new Rect(_offsetX, _background.uvRect.y, _background.uvRect.width, _background.uvRect.height);
    }
}
