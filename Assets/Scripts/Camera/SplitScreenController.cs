using UnityEngine;
using System.Collections;

public class SplitScreenController : MonoBehaviour {

	public Camera[] cameras;
	// Use this for initialization
	void Start () {
		if(GameManager.Instance.numPlayers == 1) {
			Set1Person();
		}
		else if(GameManager.Instance.numPlayers == 2) {
			Set2Persion();
		} else if(GameManager.Instance.numPlayers > 2) {
			Set4Persion(GameManager.Instance.numPlayers > 3);
		}
	}
	void Set1Person() {
		
		cameras[0].rect = new Rect(0f,0f,1f,1f);
		cameras[1].enabled = false;
		cameras[2].enabled = false;
		cameras[3].enabled = false;
	}
	void Set2Persion() {
		cameras[0].rect = new Rect(0f,0f,.5f,1f);
		cameras[1].rect = new Rect(.5f,0f,.5f,1f);
		cameras[2].enabled = false;
		cameras[3].enabled = false;

	}
	void Set4Persion(bool fourth) {
		cameras[2].enabled = true;
		cameras[3].enabled = fourth;
		cameras[0].rect = new Rect(0f,0f,.5f,.5f);
		cameras[1].rect = new Rect(.5f,0f,.5f,.5f);
		cameras[2].rect = new Rect(0f,.5f,.5f,.5f);
		cameras[3].rect = new Rect(.5f	,.5f,.5f,.5f);
	}
}
