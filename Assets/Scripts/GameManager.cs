using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public bool[] Alive;
	public int activePlayers;
	private int deadPlayers;
	public int numPlayers;
	public bool gameOver;
	public bool menu;
	private float since;
	private bool[] diedLastUpdate = new bool[4];

    private string[] playerColors = { "Blue", "Green", "Orange", "Pink" };
	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(this.gameObject);
		} else {
			
			// Here we save our singleton instance
			Instance = this;
			
			// Furthermore we make sure that we don't destroy between scenes (this is optional)
			DontDestroyOnLoad(gameObject);
		}
	}
	void Update() {
		if(gameOver) {
			since += Time.unscaledDeltaTime;
			if(since > 2f && Input.anyKey ){
				Time.timeScale = 1;
				gameOver = false;
				menu = true;
				Application.LoadLevel(0);
			}
		} else if(!menu){
			CheckWinner();
			resetLastUpdate();
		}
	}
	public void SetNumPlayers(int players) {
		activePlayers = players;
		deadPlayers = 0;
		numPlayers = players;
		Alive = new bool[4];
		Alive[0] = true;
		Alive[1] = true;
		Alive[2] = true;
		Alive[3] = true;
		resetLastUpdate();
		gameOver = false;
		menu = false;
		Time.timeScale = 1;
	}
	public void resetLastUpdate() {		
		diedLastUpdate[0] = false;
		diedLastUpdate[1] = false;
		diedLastUpdate[2] = false;
		diedLastUpdate[3] = false;
	}
	public void Dead(int player) {
		Alive[player] = false;
		diedLastUpdate[player] = true;
		deadPlayers++;
		Debug.Log(string.Format("player is dead {0}",player));
	}
	public void CheckWinner() {
		if(deadPlayers+1 >= activePlayers) {
			string winner = Winner();
			Debug.Log(string.Format("Game Over winner: {0}", winner));
			var winingText = FindObjectOfType<WinningText>();
			if(winingText != null) {
				var text = winingText.GetComponent<Text>();
				text.text = string.Format("Game Over\n{0} Won", winner);
				text.enabled = true;
				Time.timeScale = 0;
				gameOver = true;
			}
		}
	}
	private string Winner() {
        StringBuilder builder = new StringBuilder();
		for(int i =0; i < activePlayers;i++) {
			if(Alive[i]) {
                builder.Append(playerColors[i]);
                builder.Append(" Player");
                return builder.ToString();
			}
		}
		int count = 0;
		for(int i =0; i < activePlayers;i++) {
			if(diedLastUpdate[i]) {
				if(count> 0) {
					builder.Append(", ");
				}
				builder.Append(playerColors[i]);
                builder.Append(" Player");
				count++;
			}
		}
		return builder.ToString();
	}
}
