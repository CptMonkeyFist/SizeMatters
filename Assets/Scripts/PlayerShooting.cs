using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerShooting : MonoBehaviour {
	
	public GameObject bullet;
	public float timeBetween;
	public float force;
	public float timeBulletToLive;
	public Camera playerCamera;
	public GameObject FireSound;
    public Material bulletMaterial;

	private BigSmall bigSmall;
	private float since;

    int currentParticleSystem = 0;
    private ParticleSystem[] gunParticleSystems;
    private string controller = "0";

    bool shooting = false;
	
	// Use this for initialization
	void Start () {
		since = timeBetween;
		bigSmall = GetComponent<BigSmall>();
        gunParticleSystems = GetComponentsInChildren<ParticleSystem>();
        controller = GetComponent<RigidbodyFirstPersonController>().ControllerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		since += Time.deltaTime;
		if(Input.GetButton ("Fire1"+controller)  && since > timeBetween / transform.localScale.y)
		{
            gunParticleSystems[currentParticleSystem].Stop();
            gunParticleSystems[currentParticleSystem].Play();
            currentParticleSystem = (currentParticleSystem + 1) % 2;
            shooting = true;
			since = 0;
		}
		
	}
	
	void FixedUpdate()
	{
		if(shooting)
		{
			shooting = false;

			GameObject bulletInstance = (GameObject)Instantiate(bullet,transform.position, playerCamera.transform.rotation);
            Renderer bulletRenderer = bulletInstance.GetComponent<Renderer>();
            bulletRenderer.material = bulletMaterial;
            bulletInstance.transform.localScale = (transform.localScale - new Vector3(1.0f, 1.0f, 1.0f)) * 3 + new Vector3(1.0f, 1.0f, 1.0f);
            

            var bulletForce = playerCamera.transform.forward * force * transform.localScale.y * transform.localScale.y;
			Debug.Log(string.Format("{0}",bulletForce));
			bulletInstance.GetComponent<Rigidbody>().AddForce(bulletForce);
			bulletInstance.GetComponent<BulletController>().Fired = bigSmall;
			SoundManager.Instance.PlayAudio(FireSound);
			Object.Destroy(bulletInstance, timeBulletToLive);
		}
	}
}