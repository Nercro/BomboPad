using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectPlayerButtonController : MonoBehaviour {

    public UISelectPlayerController uiSelectPlayerController;

    public void NextPLayer()
    {
        uiSelectPlayerController.NextPlayer();
    }

    public void PreviousPlayer()
    {
        uiSelectPlayerController.PreviousPlayer();
    }

}
