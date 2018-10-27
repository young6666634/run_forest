using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_Follow : MonoBehaviour {
    public Transform target;
    Transform _Transform;
	// Use this for initialization
	void Start () {
        _Transform=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //追隨
        Vector3 followPos = new Vector3(target.position.x+3.525f, 0, -10);
        _Transform.position = followPos;

	}
}
