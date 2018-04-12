using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform targetToFollow;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        targetToFollow = targetToFollow.GetComponent<Transform>();
    }

    
    void Update ()
    {
        _transform.position = new Vector3(targetToFollow.position.x, _transform.position.y, _transform.position.z);
        
	}
}
