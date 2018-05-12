using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string sceneName;
    public int playerSelection = 0;

    public void LoadScene()
    {
        PlayerPrefs.SetInt("playerSelection", playerSelection);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
