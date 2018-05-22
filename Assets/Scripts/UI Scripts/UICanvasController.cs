using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasController : MonoBehaviour {

    public Canvas openCanvas;
    public Canvas canvasToDisable;

    private void Awake()
    {
        openCanvas.enabled = false;
    }

    public void EnableCanvas()
    {
        canvasToDisable.enabled = false;

        openCanvas.enabled = true;
    }

    public void DisableCanvas()
    {
        openCanvas.enabled = false;

        canvasToDisable.enabled = true;
    }
}
