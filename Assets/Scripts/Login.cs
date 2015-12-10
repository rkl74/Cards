using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
	public static string Username;
	
	public void OnEnable() {
		GameLogin();
	}
	
	private void GameLogin() {
		if (string.IsNullOrEmpty(Login.Username)) {
			return;
		}
		
		
	}
}
