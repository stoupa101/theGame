using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	private bool selected = false;
	private bool register = false;   // We only need one boolean, because if they are NOT registering, then they are logging in.
	private string userName = "", passWord = "", verifyPass = "", eMail = "";
	private string registerError = "";
	public Texture loginTexture, registerTexture;

	NetworkingClient _networkingClient;

	// Use this for initialization
	void Start () {
		_networkingClient = GameObject.FindGameObjectWithTag("Networking").GetComponent<NetworkingClient>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		//If !connected
		if(selected) {
			if(register) { // If we are registering
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), registerTexture);
				userName = GUI.TextField(new Rect(277, 163, 580, 30), userName);
				passWord = GUI.PasswordField(new Rect(275, 248, 580, 30), passWord, '*');
				verifyPass = GUI.PasswordField(new Rect(275, 333, 580, 30), verifyPass, '*');
				eMail = GUI.TextArea(new Rect(225, 417, 630, 30), eMail);
				GUI.Label(new Rect(275, 550, 550, 50), registerError);
				if(GUI.Button (new Rect(110, 475, 300, 60), "Register")) {
					if(userName.Length < 3) {
						registerError = "Username must be atleast 3 chars";
						return;
					}
					
					if(passWord.Length < 3) {
						registerError = "Password must be atleast 3 chars";
						return;
					}
					
					if(userName.Length > 12) {
						registerError = "Username cannot exceed 12 chars";
						return;
					}
					
					if(passWord.Length > 20) {
						registerError = "Password cannot exceed 20 chars";
						return;
					}
					
					if(passWord != verifyPass) {
						registerError = "Passwords do not match";
						return;
					}
					
					if(eMail.Length < 3) {
						registerError = "Please enter an email";
						return;
					}
					
					if(eMail.Contains("@") && eMail.Contains(".")) {
						
					} else {
						registerError = "Please enter a valid Email";
						return;
					}
					
					registerError = "Yay";
					
				}
				
				if(GUI.Button (new Rect(553, 475, 300, 60), "Back")) {
						selected = false;
				}
			} else { // If we are not registering.
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loginTexture);
				userName = GUI.TextField(new Rect(275, 270, 580, 30), userName);
				passWord = GUI.PasswordField(new Rect(275, 355, 580, 30), passWord, '*');
				if(GUI.Button (new Rect(100, 450, 300, 100), "Login")) {
					_networkingClient.Connect(userName, passWord);
				}
				if(GUI.Button (new Rect(550, 450, 300, 100), "Back")) {
					selected = false;
				}
			}
		} else {
			if(GUI.Button (new Rect(10, 10, 100, 40), "Login")) {
				register = false;
				selected = true;
			} else if(GUI.Button (new Rect(10, 60, 100, 40), "Register")) {
				register = true;
				selected = true;
			}
		}
	} 
		
}
