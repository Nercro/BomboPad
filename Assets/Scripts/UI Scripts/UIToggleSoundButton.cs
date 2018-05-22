using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIToggleSoundButton : MonoBehaviour {

    [Header("0 = Sound ON Image, 1 = Sound OFF Image")]
    public List<Sprite> SoundToggleSprites = new List<Sprite>();

    private int _soundToggleSpriteIndex = 0;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();

    }

    public void ToggleSound()
    {
        _soundToggleSpriteIndex += 1;

        if (_soundToggleSpriteIndex == 1)
        {
            AudioListener.volume = 0.0f;
            _image.sprite = SoundToggleSprites[_soundToggleSpriteIndex];
        }

        if (_soundToggleSpriteIndex > SoundToggleSprites.Count - 1)
        {
            _soundToggleSpriteIndex = 0;

            AudioListener.volume = 1.0f;

            _image.sprite = SoundToggleSprites[_soundToggleSpriteIndex];
        }
    }
}
