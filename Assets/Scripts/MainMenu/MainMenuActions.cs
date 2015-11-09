using UnityEngine;
using System.Collections;

public class MainMenuActions : MonoBehaviour {

	public void Start2PlayerGame()
    {
		GameManager.Instance.SetNumPlayers(2);
        Application.LoadLevel(1);
	}
	public void Start3PlayerGame()
	{
		GameManager.Instance.SetNumPlayers(3);
		Application.LoadLevel(1);
	}
	public void Start4PlayerGame()
	{
		GameManager.Instance.SetNumPlayers(4);
		Application.LoadLevel(1);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
