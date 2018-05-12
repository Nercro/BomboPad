using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public RuntimeAnimatorController playerAnimatorController;
    public RuntimeAnimatorController playerDamagedAnimatorController;

    public float movementSpeed = 2;

    
    private float _movementHorizontal;
    private Rigidbody2D _rigidbody2D;

    private int _playerLayer;
    private int _damageObjectLayer;
    private bool _isDamaged = false;
    private bool _isGameOver = false;

    private Animator _animator;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    [Header("Set movement boundaries")]
    [SerializeField]
    private float _xMaxLeft;
    [SerializeField]
    private float _xMaxRight;

    private void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerLayer = gameObject.layer;
        _damageObjectLayer = LayerMask.NameToLayer("ThrowingObjectDamage");

        GameManager.onHealthChangeEvent.AddListener(AnimationStart);
        GameManager.onGameOverEvent.AddListener(Move);

    }

    private void Update()
    {
        Move(_isGameOver);

        Physics2D.IgnoreLayerCollision(_playerLayer, _damageObjectLayer, _isDamaged);
    }

    private void Move(bool isGameOver)
    {
        _isGameOver = isGameOver;

        if (!_isGameOver)
        {
            _movementHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            Vector2 movement = new Vector2(_movementHorizontal * movementSpeed, 0f);
            _rigidbody2D.velocity = movement;

            float maxMove = Mathf.Clamp(transform.position.x, _xMaxLeft, _xMaxRight);                            // ograničava kretnje playera
            _transform.position = new Vector3(maxMove, transform.position.y, transform.position.z);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
                    

        if (_movementHorizontal != 0 && !_isGameOver)
            _animator.SetBool("isWalking", true);
        else
            _animator.SetBool("isWalking", false);
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

        StartCoroutine(OnDamageBlink());

        yield return new WaitForSeconds(3.0f);

        _isDamaged = false;
        _animator.SetBool("isDamaged", _isDamaged);
    }

    private IEnumerator OnDamageBlink()
    {
        _animator.runtimeAnimatorController = playerDamagedAnimatorController;


        for (int i = 0; i < 6; i++)                                         // blinkanje playera
        {                                                                   // 
            
            Color color = _spriteRenderer.color;
            color.a = 0.5f;
            _spriteRenderer.color = color;

            yield return new WaitForSeconds(0.2f);

            color.a = 1.0f;
            _spriteRenderer.color = color;

            yield return new WaitForSeconds(0.2f);
        }

        _animator.runtimeAnimatorController = playerAnimatorController;

    }
}
