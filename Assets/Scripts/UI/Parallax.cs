using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]    
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed = 0.005f;
     
    private RawImage _background;
    private float _offsetX;

    private void Start()
    {
        _background = GetComponent<RawImage>();
    }

    private void Update()
    {
        _offsetX += Time.deltaTime * _speed;

        if (_offsetX >= 1)
        {
            _offsetX = 0;
        }

        _background.uvRect = new Rect(_offsetX, _background.uvRect.y, _background.uvRect.width, _background.uvRect.height); 
    }
}
