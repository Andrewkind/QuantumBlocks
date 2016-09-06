using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform targetTransform;
	public float distanceToTarget;
	public float distanceFromTop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = targetTransform.position -
			(Vector3.forward * distanceToTarget);

		transform.LookAt(targetTransform);
	}
}
