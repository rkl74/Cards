using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController control;
	public static string username;
	// Prefabs
	public GameObject cardDisplay;
	public GameObject myStatus;
	public GameObject opponentStatus;
	public GameObject DeckSpace;
	public GameObject Graveyard;
	public GameObject Board;
	public GameObject Chat;
	
	void Awake() {
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}
	}
	
	public GameObject getDisplay() {
		return cardDisplay;
	}
}

