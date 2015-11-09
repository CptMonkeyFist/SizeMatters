using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public BigSmall Fired;
    public float rotVelocity = 3f;

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Wall")) {
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter(Collision collision) {				
		if(collision.gameObject.CompareTag("Wall")) {
			Destroy(this.gameObject);
		}
	}

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(rotVelocity, 0, 0));
    }
}
