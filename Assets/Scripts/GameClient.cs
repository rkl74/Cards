using UnityEngine;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.LoadBalancing;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GameClient : LoadBalancingClient {

	public byte MaxPlayers = 2;
	public int TurnNumber = 1;
	public int PlayerIdToMakeNextTurn;

	public bool IsMyTurn {
		get {
			return this.PlayerIdToMakeNextTurn == this.LocalPlayer.ID;
		}
	}
	
	public bool GameIsLoaded {
		get {
			return this.CurrentRoom != null && this.CurrentRoom.CustomProperties != null && this.CurrentRoom.CustomProperties.ContainsKey("pt");
		}
	}
	
	public bool GameCanStart {
		get {
			return this.CurrentRoom != null && this.CurrentRoom.Players.Count == 2;
		}
	}
	
	public bool GameWasAbandoned {
		get {
			return this.CurrentRoom != null && this.CurrentRoom.Players.Count < 2 && this.CurrentRoom.CustomProperties.ContainsKey("flips");
		}
	}
	
	public Player Opponent {
		get {
			Player opp = this.LocalPlayer.GetNext();
			return opp;
		}
	}
		
	public List<SaveGameInfo> SavedGames = new List<SaveGameInfo>();
	
	public void CreateTurnbasedRoom() {
		string newRoomName = string.Format("{0}-{1}", this.NickName, Random.Range(0,1000).ToString("D4"));
		Debug.Log(string.Format("CreateTurnbasedRoom(): {0}", newRoomName));
		RoomOptions roomOptions = new RoomOptions() {
			MaxPlayers = this.MaxPlayers
			//CustomRoomPropertiesForLobby = new string[] {}
		};
		this.OpCreateRoom(newRoomName, roomOptions, TypedLobby.Default);
	}
	
	public void HandoverTurnToNextPlayer() {
		if (this.LocalPlayer != null) {
			Player nextPlayer = this.LocalPlayer.GetNextFor(this.PlayerIdToMakeNextTurn);
			if (nextPlayer != null) {
				this.PlayerIdToMakeNextTurn = nextPlayer.ID;
				return;
			}
		}
		this.PlayerIdToMakeNextTurn = 0;
	}
}

public class SaveGameInfo {
	public int PlayerId;
	public string RoomName;
	public bool MyTurn;
	public Dictionary<string, object> AvailableProperties;
	public string ToStringFull() {
	return string.Format("\"{0}\"[{1}] {2} ({3})", RoomName, PlayerId, MyTurn, SupportClass.DictionaryToString(AvailableProperties));
	}
}