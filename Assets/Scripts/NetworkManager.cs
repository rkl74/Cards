using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("beta");
	}
	
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
