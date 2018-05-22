using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectPlayerController : MonoBehaviour {

    public List<Sprite> PlayerImages = new List<Sprite>();
    
    
    private int _playerImageIndex = 0;

    [HideInInspector]
    public int playerImageIndex
    {
        get { return _playerImageIndex; }
    }

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();

        CurrentPlayer();
    }

    private void CurrentPlayer()
    {
        _image.sprite = PlayerImages[_playerImageIndex];
    }

    public void NextPlayer()
    {
        _playerImageIndex += 1;

        if (_playerImageIndex >= PlayerImages.Count)
        {
            _playerImageIndex = 0;
            CurrentPlayer();
        }
        else
        {
            CurrentPlayer();
        }
    }

    public void PreviousPlayer()
    {
        _playerImageIndex -= 1;

        if (_playerImageIndex < 0)
        {
            _playerImageIndex = PlayerImages.Count - 1;
            CurrentPlayer();
        }
        else
        {
            CurrentPlayer();
        }
    }
}
