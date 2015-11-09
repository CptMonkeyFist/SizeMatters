using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class BigSmall : MonoBehaviour {
	public int biggestSize = 5;
	public int smallestSize = -5;
	public int currentSize;
	public Vector3 sizeChange = new Vector3(.1f,.1f,.1f);
	public GameObject[] playerObj;
	public GameObject GrowSound;
	public GameObject DeathSound;
    public float growOffset = 0.1f;

    private CapsuleCollider myCollider;
    private int controller;

    void Start()
    {
        controller = System.Int32.Parse(GetComponent<RigidbodyFirstPersonController>().ControllerNumber);
        myCollider = GetComponent<CapsuleCollider>();
    }

	void MakeBigger() {
		if(currentSize < biggestSize) {
			Debug.Log(string.Format("making bigger {0}",this.gameObject.transform.localScale+sizeChange));
			var oldPos = this.gameObject.transform.position;
			this.gameObject.transform.localScale = this.gameObject.transform.localScale+sizeChange;
            float newCenter = (gameObject.transform.localScale.y * myCollider.height - myCollider.height) / 2;
            this.gameObject.transform.position = new Vector3(oldPos.x, newCenter + growOffset, oldPos.z);
			SoundManager.Instance.PlayAudio(GrowSound);
            currentSize++;
		}
	}
	void MakeSmaller() {
		if(currentSize > smallestSize) {
			Debug.Log(string.Format("making smalle {0}",this.gameObject.transform.localScale-sizeChange));
			var oldPos = this.gameObject.transform.position;
			this.gameObject.transform.localScale = this.gameObject.transform.localScale-sizeChange;
            float newCenter = (gameObject.transform.localScale.y * myCollider.height - myCollider.height) / 2;
            this.gameObject.transform.position = new Vector3(oldPos.x, newCenter, oldPos.z);
            currentSize --;
		}
	}
	void Disable() {
		SoundManager.Instance.PlayAudio(DeathSound);
		GameManager.Instance.Dead(controller);
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<RigidbodyFirstPersonController>().enabled = false;
		GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		GetComponent<Rigidbody>().useGravity = false;

		for(int i = 0;i<playerObj.Length;i++){
			playerObj[i].SetActive(false);
		}

	}
	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Bullet")) {
			var otherBigSmall = other.gameObject.GetComponent<BulletController>().Fired;
			if(otherBigSmall.controller != controller) {
				MakeBigger();
				otherBigSmall.MakeSmaller();
				Destroy(other.gameObject);
			}
		}
		if(other.CompareTag("Ceiling")){
			Debug.Log("killing player");
			Disable();
		}
	}
}
