using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClockImageAnimationSoundController : MonoBehaviour {
    
    private Animator _animator;
    private AudioSource _audioSource;


    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();

        _audioSource.enabled = false;
        GameManager.timeLeftWarningEvent.AddListener(StartAnmiationAndSound);
    }

    

    private void StartAnmiationAndSound(bool startall)
    {
        if (startall)
        {
            _animator.SetBool("isScaling", true);
            _audioSource.enabled = true;
        }
        else
        {
            _animator.SetBool("isScaling", false);
            _audioSource.enabled = false;
        }
            
    }

   
    
   
}
