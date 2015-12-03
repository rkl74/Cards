using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardScript : MonoBehaviour {
	
	public Renderer rend;
	
	void Start() {
		rend = GetComponent<Renderer>();
	}
	
	void OnMouseOver() {
		Debug.Log("Hovering over: " + this.name);
	}
}
