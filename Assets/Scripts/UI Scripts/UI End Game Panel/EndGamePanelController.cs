using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanelController : MonoBehaviour {

    public Text endScoreText;

    public Button publishScoreButton;
    public Button tryAgainButton;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void EndGameScore(int endScore)
    {
        gameObject.SetActive(true);

        endScoreText.text = endScore.ToString();
    }
}
