using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPublishScoreButton : MonoBehaviour {

    public string url = "https://www.gofundme.com/empireofhell/";

    public void SendScore()
    {
        Application.OpenURL(url + "?" + GameManager.Instance.score);
    }
}
