using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 2;

    
    private float _movementHorizontal;
    private Rigidbody2D _rigidbody2D;

    private int _playerLayer;
    private int _damageObjectLayer;
    private bool _isDamaged = false;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _playerLayer = gameObject.layer;
        _damageObjectLayer = LayerMask.NameToLayer("ThrowingObjectDamage");

        GameManager.onHealthChangeEvent.AddListener(AnimationStart);

    }

    private void Update()
    {
        Move();

        Physics2D.IgnoreLayerCollision(_playerLayer, _damageObjectLayer, _isDamaged);
    }

    private void Move()
    {
        // TODO: ograniciti playerove kretnje pomocu clampa kada bude bila konacna velicina pozornice
        _movementHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(_movementHorizontal * movementSpeed, 0f);
        _rigidbody2D.velocity = movement;
    }

    private void AnimationStart(int amount, bool damage)
    {
        if (damage)
            StartCoroutine(OnDamageIgnoreLayer());
    }

    private IEnumerator OnDamageIgnoreLayer()
    {                                                                       //
        _isDamaged = true;                                                  // isključuje layer colision izmedu playera i damage objekta
        _animator.SetBool("isDamaged", _isDamaged);                         // pokrece animaciju
                                                                            //
        yield return new WaitForSeconds(3.0f);

        _isDamaged = false;
        _animator.SetBool("isDamaged", _isDamaged);
    }
}
