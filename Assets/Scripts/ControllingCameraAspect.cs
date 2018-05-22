using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllingCameraAspect : MonoBehaviour {

    [System.Serializable]
    public struct AspectRatio
    {
        public float widthAspect;
        public float heightAspect;
    }

    public AspectRatio aspectRatio;

    void Start()
    {
        float targetAspect = aspectRatio.widthAspect / aspectRatio.heightAspect;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }
    }
}
