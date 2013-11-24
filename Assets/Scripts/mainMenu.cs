using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	private bool selectedLogin = false;
	//string loginURL = "";

	void OnGUI ()
	{
		if(selectedLogin) {
			/*
			userName = GUI.TextField(new Rect(275, 270, 580, 30), userName);
			passWord = GUI.PasswordField(new Rect(275, 355, 580, 30), passWord, '*');
			if(GUI.Button (new Rect(100, 450, 300, 100), "Login")) {
				_networkingClient.Connect(userName, passWord);
			}
			*/
			if(GUI.Button (new Rect(Screen.width / 2, Screen.height /2 , 100, 20), "Back")) {
				selectedLogin = false;
			}

		} else {
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height /2 - 80 , 100, 20), "Login"))
			{
				selectedLogin = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height /2 - 40 , 100, 20), "Outside demo"))
			{
				Application.LoadLevel("Outside");
			}
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height /2 , 100, 20), "Inside demo"))
			{
				Application.LoadLevel("Inside");
			}
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height /2 + 40 , 100, 20), "Quit"))
			{
				Application.Quit();
			}
		}
	}
}
