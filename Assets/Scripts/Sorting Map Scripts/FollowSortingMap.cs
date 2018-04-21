using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSortingMap : MonoBehaviour {

    public SortingMap sortingMapToFollow;

    public float maxY = 0.0f;
    public Vector3 minScale;

    public bool shouldScale = true;
    public float minObjectSize = 0.5f;

    private Transform _transform;
    private Vector3 _originalScale;

    private void Awake()
    {
        _transform = transform;
        maxY = _transform.position.y;

        _originalScale = _transform.localScale;
    }

    private void Update()
    {
        UpdateToSortZone();
    }

    private void UpdateToSortZone()
    {
        
        if (shouldScale)
        {
            if (maxY > _transform.position.y) // zaključa najmanju veličinu objekta kada pocče padati prema dolje
            {
                _transform.localScale = minScale;
            }
            else
            {
                maxY = _transform.position.y;
                minScale = _transform.localScale;

                float newScale = sortingMapToFollow.GetRelativeScaleFactor(_transform);
                _transform.localScale = _originalScale * newScale;
            }


        }

        
    }
}
