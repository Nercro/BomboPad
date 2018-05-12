using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingObjectMove : MonoBehaviour {

   //[Header("Set other sprite if object has another form")]
   //public Sprite spriteImage;

    [Header("Sets offset when collider is turned on")]
    public Transform player;
    public float playerPositionOffset = 2f;
 
    private float _yMin;
    private float _yMax;

    private Transform _transform;
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _transform = transform;

        _collider2D = GetComponent<Collider2D>();

        //_spriteRenderer = GetComponent<SpriteRenderer>();

        CameraAdjust();

        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        RestrictingArea();
        
        
        // ako je objekt iznad playera ukljuciti ce se collider da može biti pogođen
        if (_transform.position.y > player.transform.position.y + playerPositionOffset)
        {
            _collider2D.enabled = true;
        }
        
        
    }

    
    private void RestrictingArea()
    {
        // postavlja maksimalnu visinu do kuda objekt može ići
        float yNew = Mathf.Clamp(_transform.position.y, _yMin, _yMax);
        _transform.position = new Vector3(_transform.position.x, yNew, _transform.position.z);
    }

    private void CameraAdjust()
    {
        
        float distance = _transform.position.z - Camera.main.transform.position.z;
        Vector3 downMax = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 upMax = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, distance));
        _yMin = downMax.y;
        _yMax = upMax.y;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor")
        {
            //_spriteRenderer.sprite = spriteImage;
        }
    }

}
