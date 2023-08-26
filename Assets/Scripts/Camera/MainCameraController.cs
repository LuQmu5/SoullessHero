using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCameraController : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector3 _offset;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        StartCoroutine(Following(_followTarget));
    }

    private IEnumerator Following(Transform target)
    {
        while (true)
        {
            transform.position = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z) + _offset;

            yield return null;
        }
    }
}
