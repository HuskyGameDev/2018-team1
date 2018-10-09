using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour {

	public Text endText;

	void Start() {
		endText.text = "";
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ( other.gameObject.tag == "endLevel" ) {
			endText.text = "Reached End of Level!!!";
		}
	}
}
