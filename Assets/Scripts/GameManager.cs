using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangedEvent : UnityEvent<int, bool> { }

public class ScoreChangedEvent : UnityEvent<int> { }

public class GameManager : MonoBehaviour
{

    public GameObject tauntLeft;    //objekt sa aminmacijom
    public GameObject tauntRigth;   //objekt sa animacijom
    
    public int maxNumOfLives = 3;
    public int currentNumOfLives = 3;

    public float timeLeft = 30;
    public Text timeLeftText;

    public int score = 0;
    public Text scoreText;

    [Header("End Game Score Canvas")]
    public EndGamePanelController endGameCanvas;

    public static HealthChangedEvent onHealthChangeEvent = new HealthChangedEvent();
    public static ScoreChangedEvent onScoreChangedEvent = new ScoreChangedEvent();

    public static GameManager Instance;
    

    private void Awake()
    {
        Instance = this;

        Time.timeScale = 1;

        //postavlja zivote na max i invoka ih u eventu
        currentNumOfLives = maxNumOfLives;
        onHealthChangeEvent.Invoke(maxNumOfLives, false);

        //postavlja score na 0
        scoreText.text = "Score: " + score.ToString();
    }

    private void Update()
    {
        CountdownTimer();

    }

    public void AddScore(int scorePoints, int addTime)
    {
        timeLeft += addTime;
        score += scorePoints;
        scoreText.text = "Score: " + score.ToString();

        onScoreChangedEvent.Invoke(score);
    }

    public void AddLife(int amount)
    {
        if (currentNumOfLives < maxNumOfLives)
        {
            currentNumOfLives += amount;
            onHealthChangeEvent.Invoke(currentNumOfLives, false);
        }
        else
        {
            currentNumOfLives = maxNumOfLives;
            onHealthChangeEvent.Invoke(currentNumOfLives,false);
        }
            
    }

    public void LoseLife(int amount)
    {
        currentNumOfLives -= amount;
        onHealthChangeEvent.Invoke(currentNumOfLives, true);

        if (currentNumOfLives <= 0)
        {
            Debug.Log("Game Over");
            endGameCanvas.EndGameScore(score);

            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(StartTauntAnimation());
        }

    }

    public void CountdownTimer()
    {
        timeLeft -= Time.deltaTime;
        timeLeftText.text = "TIME: " + timeLeft.ToString("00");

        if (timeLeft <= 0.05)
        {
            endGameCanvas.EndGameScore(score);
            Time.timeScale = 0;
        }
    }

    //ova metoda se treba invokat kada se izgubi health
    private IEnumerator StartTauntAnimation()
    {
        //enablea game objekte koji imaju namiator na sebi i nakon sta odradew animaciju ugase se
        tauntLeft.SetActive(true);
        tauntRigth.SetActive(true);

        yield return new WaitForSeconds(2f);

        tauntLeft.SetActive(false);
        tauntRigth.SetActive(false);

    }
}
