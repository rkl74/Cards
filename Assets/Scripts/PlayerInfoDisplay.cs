using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfoDisplay : MonoBehaviour {

	public GameObject username;
	public GameObject life;
	public GameObject hand_size;
	public GameObject deck_size;

	// Use this for initialization
	void Start () {
		updateLife(20);
		updateHandSize(5);
		updateDeckSize(60);
	}
	
	void setUsername(string user) {
		username.GetComponent<Text>().text = user;
	}
	
	void updateLife(int val) {
		life.GetComponent<Text>().text =  val.ToString();
	}
	
	void updateHandSize(int val) {
		hand_size.GetComponent<Text>().text = val.ToString();
	}
	
	void updateDeckSize(int val) {
		deck_size.GetComponent<Text>().text = val.ToString();
	}
}
