using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthChangedEvent : UnityEvent<int, bool> { }

public class ScoreChangedEvent : UnityEvent<int> { }

public class GameOverEvent : UnityEvent<bool> { }

public class TimeLeftWariningEvent : UnityEvent<bool> { }

public class GameManager : MonoBehaviour
{
    public List<GameObject> playerSelection = new List<GameObject>();

    [Header("Taunt Animation Game Objects")]
    public GameObject tauntLeft;    //objekt sa aminmacijom
    public GameObject tauntRigth;   //objekt sa animacijom

    [Header("Courtains closing Aniation Game Objects")]
    public GameObject courtainLeft;
    public GameObject courtainRigth;
    
    [Header("Life settings")]
    public int maxNumOfLives = 3;
    public int currentNumOfLives = 3;

    [Header("Time countdown settings")]
    public float timeLeft = 30;
    public Text timeLeftText;
    public Animator clockImageAnimation;
    [Header("Set time when event will begin")]
    public float clockImageTimeTrigger = 5.0f;

    [Header("Score settings")]
    public int score = 0;
    public Text scoreText;

    [Header("End Game Score Canvas")]
    public EndGamePanelController endGameCanvas;
    [Header("Life,Score,Time Canvas to be deactivated on game over")]
    public Canvas lifeScoreTimeManagerCanvas;

    public static HealthChangedEvent onHealthChangeEvent = new HealthChangedEvent();
    public static ScoreChangedEvent onScoreChangedEvent = new ScoreChangedEvent();
    public static GameOverEvent onGameOverEvent = new GameOverEvent();
    public static TimeLeftWariningEvent timeLeftWarningEvent = new TimeLeftWariningEvent();

    public static GameManager Instance;

    [SerializeField]
    private float _waitOnGameOver = 2.0f;

    private void Awake()
    {
        Instance = this;

        Instantiate(playerSelection[PlayerPrefs.GetInt("playerSelection")]);

        Time.timeScale = 1;

        

        //postavlja score na 0
        scoreText.text = score.ToString();
    }

    private void Start()
    {
        //postavlja zivote na max i invoka ih u eventu
        currentNumOfLives = maxNumOfLives;
        onHealthChangeEvent.Invoke(maxNumOfLives, false);
    }

    private void Update()
    {
        CountdownTimer();

    }

    public void AddScore(int scorePoints, int addTime)
    {
        timeLeft += addTime;
        score += scorePoints;
        scoreText.text = score.ToString();

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
            onGameOverEvent.Invoke(true);

            StartCoroutine(OnGameOver());
        }
        else
        {
            StartCoroutine(StartTauntAnimation());
        }

    }

    public void CountdownTimer()
    {
        timeLeft -= Time.deltaTime;
        timeLeftText.text = timeLeft.ToString("00");

        if (timeLeft <= clockImageTimeTrigger)
            timeLeftWarningEvent.Invoke(true);
        else
            timeLeftWarningEvent.Invoke(false);




        if (timeLeft <= 0.05)
        {
            timeLeft = 0.0f;
            onGameOverEvent.Invoke(true);
            timeLeftWarningEvent.Invoke(false);

            StartCoroutine(OnGameOver());
        }
    }

    private IEnumerator CountdownClockScale()
    {
        clockImageAnimation.SetBool("isScaling", true);

        yield return new WaitForSeconds(2.0f);

        clockImageAnimation.SetBool("isScaling", false);
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

    private IEnumerator OnGameOver()
    {
        courtainLeft.SetActive(true);
        courtainRigth.SetActive(true);

        yield return new WaitForSeconds(_waitOnGameOver);

        lifeScoreTimeManagerCanvas.enabled = false;
        endGameCanvas.EndGameScore(score);
        Time.timeScale = 0;
    }
}
