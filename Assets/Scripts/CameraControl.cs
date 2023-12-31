using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _positionCamera;
    [SerializeField] private Vector3 _rotationCamera;
    [SerializeField] private float _moveSpeedCamera;
    
    void Start()
    {
        transform.position = _playerTransform.position;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (_playerTransform == null)
        {
            Debug.LogError("Player transform is null.");
            return;
        }
        
        Vector3 newCameraPosition = _playerTransform.position + _positionCamera;
        Vector3 smoothCameraPosition = Vector3.Lerp(transform.position, newCameraPosition, _moveSpeedCamera);
        transform.position = smoothCameraPosition;
        transform.eulerAngles = _rotationCamera;
    }
}
