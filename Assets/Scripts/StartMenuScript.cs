using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class StartMenuScript : MonoBehaviour {
	public Canvas quitMenu;
	public GameObject login;
	public GameObject registration;
	public Button loginBtn;
	public Button registerBtn;

	// Login Variables
	public InputField loginUser;
	public InputField loginPassword;
	
	// Registration Variables
	public InputField userField;
	public InputField emailField;
	public InputField password;
	public InputField confirm;
	
	public Text LoginErrorMsg;
	public Text UsernameErrorMsg;
	public Text EmailErrorMsg;
	public Text PasswordErrorMsg;
	
	public string emailNotAvailable = "That email address has already been registered.";
	public string usernameNotAvailable = "That user name has already been taken.";
	public string invalidPassword = "Password is invalid (8-24 characters).";
	public string invalidUsername = "User name is invalid (3-24 characters).";
	
	// Use this for initialization
	void Start() {
		quitMenu = quitMenu.GetComponent<Canvas>();
		loginBtn = loginBtn.GetComponent<Button>();
		quitMenu.enabled = false;
		registration.SetActive(false);
		LoginErrorMsg.text = "";
		UsernameErrorMsg.text = "";
		EmailErrorMsg.text = "";
		PasswordErrorMsg.text = "";
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			exitPressed();
		}
	}

	private void clearRegistration() {
		userField.text = "";
		emailField.text = "";
		password.text = "";
		confirm.text = "";

		UsernameErrorMsg.text = "";
		EmailErrorMsg.text = "";
		PasswordErrorMsg.text = "";
	}
	
	private void clearLogin() {
		loginPassword.text = "";
		LoginErrorMsg.text = "";
	}
	
	const string pattern = @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
	private bool validateEmail() {
		bool validated = Regex.IsMatch(emailField.text, pattern);
		if (validated) {
			EmailErrorMsg.text = "";
		}
		else {
			EmailErrorMsg.text = "Please enter a valid email address.";
		}
		return validated;
	}
	
	private bool validatePassword() {
		bool validated = password.text.Length >= 8 && password.text.Length <= 24 && password.text == confirm.text;
		if (validated) {
			PasswordErrorMsg.text = "";
		}
		else {
			if (!(password.text.Length >= 8 && password.text.Length <= 24)) {
				PasswordErrorMsg.text = invalidPassword;
			}
			if (password.text != confirm.text) {
				PasswordErrorMsg.text += " Passwords do not match. Please confirm your password.";
			}
		}
		return validated;
	}
	
	private bool checkUsername() {
		bool validated = userField.text.Length >= 3 && userField.text.Length <= 24;
		if (validated) {
			UsernameErrorMsg.text = "";
		}
		else {
			UsernameErrorMsg.text = invalidUsername;
		}
		return validated;
	}
	
	public void register() {
		bool userOK = checkUsername();
		bool emailOK = validateEmail();
		bool passwordOK = validatePassword();
		if (userOK && emailOK && passwordOK) {
			Debug.Log("Success!");
		}
		else {
			Debug.Log("Registration failed!");
		}
	}
	
	public void showRegisterScreen() {
		clearLogin();
		registration.SetActive(true);
		login.SetActive(false);
	}
	
	public void showLoginScreen() {
		clearRegistration();
		registration.SetActive(false);
		login.SetActive(true);
	}
	
	public void exitPressed() {
		quitMenu.enabled = true;
		loginBtn.enabled = false;
		registerBtn.enabled = false;
	}
	
	public void NoPressed() {
		quitMenu.enabled = false;
		loginBtn.enabled = true;
		registerBtn.enabled = true;
	}
	
	public void GameLogin() {
		// Login Authentication method
		// Verify login credentials
		Application.LoadLevel("Board");
	}
	
	public void ExitGame() {
		Application.Quit();
	}
}
