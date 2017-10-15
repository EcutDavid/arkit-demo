using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour {
	void Start () {
		transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
	}

	int counter = 0;
	// Update is called once per frame
	void Update () {
		if (counter++ < 100) {
			transform.localScale = new Vector3 (0.01f + 0.0001f * counter, 0.01f + 0.0001f * counter, 0.01f + 0.0001f * counter);
		}
	}
}
