using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanelController : MonoBehaviour {

    public Image lifeFullImage;

    public void SetActive(bool value)
    {
        lifeFullImage.enabled = value;
    }
	
}
