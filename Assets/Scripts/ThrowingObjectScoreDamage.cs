using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingObjectScoreDamage : MonoBehaviour {

    public bool doesDamage = false;
    public int scoreValue = 1;
    public int addTimeValue = 2;
    public int damageValue = 1;
    public bool addsLife = false;
    public int addLifeValue = 1;

    
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
}
