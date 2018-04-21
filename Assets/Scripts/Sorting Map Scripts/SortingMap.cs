using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SortZone
{
    public Color gizmosColor = Color.red;
    public float offsetY = 0.0f;
    public float scaleFactor = 0.0f;
}

public class SortingMap : MonoBehaviour {

    public float startScaleFactor = 1.0f;

    public List<SortZone> SortZones = new List<SortZone>();

    public SortZone GetSortZone(Transform objectToSort)
    {
        SortZone sortZone = new SortZone();

        if (SortZones.Count > 0)
        {
            float objectY = objectToSort.transform.position.y;
            float sortingMapY = transform.position.y;

            if (objectY < sortingMapY + SortZones[0].offsetY)
                return SortZones[0];

            for (int i = SortZones.Count -1; i >= 1; i--)
            {
                float sortZoneY = sortingMapY + SortZones[i -1].offsetY;

                if (objectY > sortZoneY)
                    return SortZones[i];
            }
        }

        return sortZone;
    }

    public float GetRelativeScaleFactor(Transform objectToSort)
    {
        SortZone sortZone = GetSortZone(objectToSort);
        int zoneIndex = SortZones.IndexOf(sortZone);

        float objectY = objectToSort.transform.position.y;
        float sortingMapY = transform.position.y;

        float relativeScaleFactor = startScaleFactor;

        if (objectY < sortingMapY)
            return startScaleFactor;

        if (objectY > (sortingMapY + SortZones[SortZones.Count - 1].offsetY))
            return SortZones[SortZones.Count - 1].scaleFactor;

        float previousZoneEdgeY = sortingMapY;
        float zoneEdgeY = sortingMapY + sortZone.offsetY;
        float previousZoneScaleFactor = startScaleFactor;

        if (zoneIndex != 0)
        {
            previousZoneEdgeY += SortZones[zoneIndex - 1].offsetY;
            previousZoneScaleFactor = SortZones[zoneIndex - 1].scaleFactor;
        }

        float interpolationFactor = (objectY - previousZoneEdgeY) / (zoneEdgeY - previousZoneEdgeY);
        float relativeScale = Mathf.Lerp(previousZoneScaleFactor, sortZone.scaleFactor, interpolationFactor);

        return relativeScale;
    }

    private void OnDrawGizmos()
    {
        
        for (int i = SortZones.Count -1; i >= 0; i--)
        {

            Gizmos.color = SortZones[i].gizmosColor;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.up * SortZones[i].offsetY);
        }
    }
}
