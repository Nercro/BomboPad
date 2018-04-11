using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 2;

    private Transform _transform;
    private float _movementHorizontal;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movementHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(_movementHorizontal * movementSpeed, 0f);
        _rigidbody2D.velocity = movement;
    }
}
