  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 2, 0, 0);
		if (transform.rotation.eulerAngles.y >= 90 && transform.rotation.eulerAngles.y < 180) {
			transform.Rotate(0, -180, 0, 0);
		}
	}
}
