using UnityEngine;
using System.Collections;

public class ConstantPositionChange : MonoBehaviour {
	public Vector3 Change;
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = this.transform.position + (Time.fixedDeltaTime * Change);
	}
}
