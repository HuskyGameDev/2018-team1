using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleportToStart : MonoBehaviour {

	public Transform startObj;
	private Vector3 startPos;

	public Text test;

	private Transform transform;

	void Start() {
		transform = GetComponent<Transform>();
		startPos = new Vector3(startObj.position.x, transform.position.y, transform.position.z);
		test.text = "";
	}

	void Update() {
		if (Input.GetKey("l")) {
			transform.position = startPos;
			test.text = "";
		}
	}
}
