using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 2;

    
    private float _movementHorizontal;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // TODO: ograniciti playerove kretnje pomocu clampa kada bude bila konacna velicina pozornice
        _movementHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(_movementHorizontal * movementSpeed * Time.deltaTime, 0f);
        _rigidbody2D.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("player HIT " + other.name);
    }
}
