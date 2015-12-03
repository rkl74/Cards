using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LayoutScript : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			Debug.Log(hit.collider.name);
		}
	}
}
