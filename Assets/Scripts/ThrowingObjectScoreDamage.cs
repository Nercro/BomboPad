using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingObjectScoreDamage : MonoBehaviour {

    public bool doesDamage = false;
    public int scoreValue = 1;
    public int damageValue = 1;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && doesDamage)
        {
            GameManager.Instance.LoseLife(damageValue);

            Destroy(gameObject);
        }
        else if (other.tag == "Player" && !doesDamage)
        {
            GameManager.Instance.AddScore(scoreValue);

            Destroy(gameObject);
        }
    }
}
