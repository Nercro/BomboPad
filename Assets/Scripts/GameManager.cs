using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthChangedEvent : UnityEvent<int> { }

public class GameManager : MonoBehaviour
{
    public int maxNumOfLives = 3;
    public int currentNumOfLives = 3;

    public int score = 0;

    public static HealthChangedEvent onHealthChangeEvent = new HealthChangedEvent();

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;

        currentNumOfLives = maxNumOfLives;
        onHealthChangeEvent.Invoke(maxNumOfLives);
    }

    public void AddScore(int scorePoints)
    {
        score += scorePoints;
    }

    public void AddLife(int amount)
    {
        if (currentNumOfLives < maxNumOfLives)
        {
            currentNumOfLives += amount;
            onHealthChangeEvent.Invoke(currentNumOfLives);
        }
        else
        {
            currentNumOfLives = maxNumOfLives;
            onHealthChangeEvent.Invoke(currentNumOfLives);
        }
            
    }

    public void LoseLife(int amount)
    {
        currentNumOfLives -= amount;
        onHealthChangeEvent.Invoke(currentNumOfLives);

        if (currentNumOfLives <= 0)
            Debug.Log("Game Over");
    }

}
