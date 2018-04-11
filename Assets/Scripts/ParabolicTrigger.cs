using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D _rigidbody2D = other.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.zero;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
