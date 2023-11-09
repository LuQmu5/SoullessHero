using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private Texture[] _textures;
    [SerializeField] private float _fps = 30f;

    private LineRenderer _lineRenderer;
    private float _fpsCounter;
    private int _animationStep;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _fpsCounter += Time.deltaTime;

        if( _fpsCounter >= 1 / _fps)
        {
            _animationStep++;
            if (_animationStep == _textures.Length)
                _animationStep = 0;

            _lineRenderer.material.SetTexture("_MainTex", _textures[_animationStep]);

            _fpsCounter = 0f;
        }
    }
}
