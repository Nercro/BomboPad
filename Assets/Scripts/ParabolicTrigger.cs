using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D _rigidbody2D = other.GetComponent<Rigidbody2D>();                      // kada dotakne trigger objekt dobije ubrzanje prema dolje
        //_rigidbody2D.velocity = Vector2.zero;                                            //
        _rigidbody2D.velocity = Vector2.down * 2;


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
