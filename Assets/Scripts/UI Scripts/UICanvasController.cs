using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasController : MonoBehaviour {

    public Canvas openCanvas;
    public Canvas mainMenuCanvas;

    private void Awake()
    {
        openCanvas.enabled = false;
    }

    public void EnableCanvas()
    {
        mainMenuCanvas.enabled = false;

        openCanvas.enabled = true;
    }

    public void DisableCanvas()
    {
        openCanvas.enabled = false;

        mainMenuCanvas.enabled = true;
    }
}
