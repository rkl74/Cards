using UnityEngine;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.LoadBalancing;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	private GameClient client;
	public string AppId;
	public string region;

	public enum GameState { Login, Lobby, DeckBuilding, InGame }
	public GameState CurrentState = GameState.Login;
	
	void Awake() {
		if (string.IsNullOrEmpty(this.AppId)) {
			Debug.LogError("Must enter AppId for Photon TurnBased.");
			Debug.Break();
		}
		Application.runInBackground = true;
	}
	
	public void OnEnable() {
		client = new GameClient();
		client.AppId = this.AppId;
		client.ConnectToRegionMaster(this.region);
	}

	public void NewRandomGameMsg() {
		CurrentState = GameState.InGame;
		client.OpJoinRandomRoom(null, 0);
	}
	
	public void LoadGameMsg(object[] parameters) {
		string name = parameters[0] as string;
		int actorNumber = (int)parameters[1];
		Debug.Log(string.Format("LoadGameMsg: {0} #{1}", name, actorNumber));
		client.OpJoinRoom(name, actorNumber);
	}
	
	public void LeaveGameMsg() {
		LeaveGameMsg(false);
	}
	
	public void LeaveGameMsg(bool toAbandon) {
		client.OpLeaveRoom(!toAbandon);
	}

	void Update() {
		client.Service();
	}
	
	void OnApplicationQuit() {
		client.Disconnect();
	}
}