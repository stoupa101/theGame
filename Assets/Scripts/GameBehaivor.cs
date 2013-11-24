using UnityEngine;
using System.Collections;

public class GameBehaivor : MonoBehaviour {

	void Update () {
		if(Input.GetButtonDown("Esc")) {
			Application.LoadLevel("MainMenu");
		}
	
	}
}
