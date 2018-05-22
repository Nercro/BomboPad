using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenuCanvasController : MonoBehaviour {

    public Canvas pauseGamecanvas;

    public Sprite pauseGameImage;
    public Sprite continueGameImage;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();

        pauseGamecanvas.enabled = false;

        _image.sprite = pauseGameImage;
    }

    public void EnablePauseGameCanvas()
    {
        if (Time.timeScale == 0)
            DisablePauseGameCanvas();
        else
        {
            Time.timeScale = 0;

            pauseGamecanvas.enabled = true;

            _image.sprite = continueGameImage;
        }
        
    }

    public void DisablePauseGameCanvas()
    {
        Time.timeScale = 1;
        
        pauseGamecanvas.enabled = false;

        _image.sprite = pauseGameImage;
    }
}
