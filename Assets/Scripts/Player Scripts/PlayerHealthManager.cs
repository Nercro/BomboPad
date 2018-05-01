using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class PlayerHealthManager : MonoBehaviour {
    /*
    public int numOfLives = 3;

    public int currentNumOfLives = 3;

    public HealthChangedEvent onHealthChangeEvent = new HealthChangedEvent();

    private void Awake()
    {
        currentNumOfLives = numOfLives;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ThrowingObject")
        {

        }
    }

    public void LoseHealth(int amount)
    {
        currentNumOfLives -= amount;

        if (currentNumOfLives <= 0)
            Debug.Log("game over");

        onHealthChangeEvent.Invoke(currentNumOfLives);
    }

    public void AddHealth(int amount)
    {
        if (currentNumOfLives < numOfLives)
            currentNumOfLives += amount;
        else
            currentNumOfLives = numOfLives;

        onHealthChangeEvent.Invoke(currentNumOfLives);
    }*/
}
