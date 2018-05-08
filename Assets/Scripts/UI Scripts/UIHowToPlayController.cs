using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHowToPlayController : MonoBehaviour {

    public Canvas howToPlaycanvas;
    public Canvas mainMenuCanvas;

    private void Awake()
    {
        howToPlaycanvas.enabled = false;
    }

    public void EnableCanvas()
    {
        mainMenuCanvas.enabled = false;

        howToPlaycanvas.enabled = true;
    }

    public void DisableCanvas()
    {
        howToPlaycanvas.enabled = false;

        mainMenuCanvas.enabled = true;
    }
}
