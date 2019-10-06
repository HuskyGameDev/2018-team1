using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstLoad : MonoBehaviour {

	public Image img;
	// Use this for initialization
	void Start () {
		if (!Global.firstRun)
		{
			img.color = new Color(1f, 1f, 1f, 0f);
		}
		else
		{
			img.color = new Color(1f, 1f, 1f);
			Global.firstRun = false;
		}
	}
}
