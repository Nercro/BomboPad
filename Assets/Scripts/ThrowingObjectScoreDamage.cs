using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ObjectSprites
{
    public Sprite mainSprite;
    public Sprite onFloorSprite;

}

public class ThrowingObjectScoreDamage : MonoBehaviour {

    public bool doesDamage = false;
    public int scoreValue = 1;
    public int addTimeValue = 2;
    public int damageValue = 1;
    public bool addsLife = false;
    public int addLifeValue = 1;

    public List<ObjectSprites> objectSprites = new List<ObjectSprites>();

    private int _objectSpriteIndex = 0;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        RandomSprite();
    }

    public void RandomSprite()
    {
        _objectSpriteIndex = UnityEngine.Random.Range(0, objectSprites.Count);

        _spriteRenderer.sprite = objectSprites[_objectSpriteIndex].mainSprite;
    }

    // TODO: ove uvjete malo bolje poslozit
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && doesDamage)
        {
            GameManager.Instance.LoseLife(damageValue);

            Destroy(gameObject);
        }
        else if (other.tag == "Player" && !doesDamage && !addsLife)
        {
            GameManager.Instance.AddScore(scoreValue, addTimeValue);

            Destroy(gameObject);
        }
        else if (other.tag == "Player" && addsLife && !doesDamage)
        {
            GameManager.Instance.AddLife(addLifeValue);
            Debug.Log("added life");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor")
        {
            _spriteRenderer.sprite = objectSprites[_objectSpriteIndex].onFloorSprite;
        }
    }
}
