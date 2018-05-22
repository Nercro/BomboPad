using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISelectPlayerStartButton : MonoBehaviour {

    public UISelectPlayerController uiSelectPlayerController;

    public string sceneName;


    public void LoadScene()
    {
        PlayerPrefs.SetInt("playerSelection", uiSelectPlayerController.playerImageIndex);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
