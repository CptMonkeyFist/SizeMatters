using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	public static SoundManager Instance;
	
	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		} else {
			 
			// Here we save our singleton instance
			Instance = this;
		}
	}
	public void PlayAudio(GameObject audioclip) {
		if(audioclip != null) {
			var audio = Instantiate(audioclip,this.transform.position,Quaternion.identity);
			Object.Destroy(audio,2.0f);
		}
	}
}
