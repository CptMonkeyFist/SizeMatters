using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {
	public string controller;
	public GameObject Win;
	// Use this for initialization
	void Start () {
		controller = GetComponent<RigidbodyFirstPersonController>().ControllerNumber;
		if(GameManager.Instance.activePlayers <= int.Parse(controller)) {
			this.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Won() {
		Win.SetActive(true);
	}
}
