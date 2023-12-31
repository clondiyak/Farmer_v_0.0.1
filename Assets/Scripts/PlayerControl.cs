using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4;
    
    private Rigidbody _rb;
    private Vector3 _moveDirection;

    private float _horizontal;
    private float _vertical;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector3(_horizontal, 0, _vertical).normalized * _moveSpeed;

        _rb.velocity = _moveDirection;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Garden"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.GetComponent<GardenControl>().Plant();
            }
            else if (Input.GetKey(KeyCode.R))
            {
                other.GetComponent<GardenControl>().Collect();
            }
        }
    }
}
