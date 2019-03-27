using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float leftBound;
	public float rightBound;

	private float cameraWidth;

	// Use this for initialization
	void Start () {
		cameraWidth = transform.parent.gameObject.GetComponent<Camera>().orthographicSize * 2;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float parentXPos = transform.parent.position.x;

		print("parent pos: " + parentXPos);

		float width = rightBound - leftBound;
		float percentageAcross = (rightBound - parentXPos) / width;

		print("percentage across: " + percentageAcross);

		percentageAcross -= 0.5f;

		transform.localPosition = new Vector3(2 * percentageAcross * cameraWidth, transform.localPosition.y, transform.localPosition.z);

	}
}
