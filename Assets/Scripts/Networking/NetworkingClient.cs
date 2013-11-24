using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities;

//Test dle tutorialu http://www.youtube.com/channel/UCnuvs9t_nIcTrpDInPa0rZA
public class NetworkingClient : MonoBehaviour {

	private string host = "localhost";
	private int port = 9993;
	private string userName = "",passWord = "",zoneName = "BasicExamples";

	public SmartFox _client;
	
	// Use this for initialization
	void Start () {
		_client = new SmartFox();
		_client.ThreadSafeMode = true;
		_client.AddEventListener(SFSEvent.CONNECTION, OnConnection);
		_client.AddEventListener(SFSEvent.LOGIN, OnLogin);
		_client.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_client.ProcessEvents();
	
	}

	public void Connect(string _userName, string _passWord) {
		this.userName = _userName;
		this.passWord = _passWord;
		_client.Connect(host, port);
	}

	void OnConnection(BaseEvent _event) {
		if ((bool) _event.Params["success"]) {
			Debug.Log("Spojeni OK");
			_client.Send(new LoginRequest(userName, passWord, zoneName));
			
		} else {
			Debug.Log("NEspojeno");
		}
	}

	void OnLogin(BaseEvent _event) {
		Debug.Log("Logged in: " + _event.Params["user"]);
	}
	void OnLoginError(BaseEvent _event) {
		Debug.Log("Error: " + _event.Params["errorCode"] + ", " + _event.Params["errormessage"]);
	}
}
