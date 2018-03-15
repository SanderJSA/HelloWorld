﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

	private const string VERSION = "v0.0.1";

	public string roomName = "Room#001";

	public GameObject Player2;
	
	void Start ()
	{
		Connect ();
	}

	void Connect ()
	{
		PhotonNetwork.ConnectUsingSettings ( VERSION );
	}

	void OnJoinedLobby ()
	{
		PhotonNetwork.JoinRoom ( this.roomName );
	}

	void OnPhotonJoinRoomFailed ()
	{
		PhotonNetwork.CreateRoom ( this.roomName );
	}
	
	void OnJoinedRoom ()
	{
		Debug.Log ( "RoomJoined" );
		
		string objectToSpawn = "Player" + (PhotonNetwork.countOfPlayersInRooms % 2 + 1) % 10;
		
		Debug.Log ( objectToSpawn );

		Cube = PhotonNetwork.Instantiate ( objectToSpawn, Vector3.zero, Quaternion.identity, 0 );
	}

	private GameObject Cube;
	
	void MoveCube ()
	{
		this.Cube.transform.position += Vector3.up;
	}

	void Update ()
	{
		if (Input.GetKeyDown ( KeyCode.B ))
			MoveCube ();
	}
	

	void SpawnMyPlayer ()
	{
		/*
		GameObject go = PhotonNetwork.Instantiate ( "player", Vector3.zero, Quaternion.identity, 0 );

		PlayerScript ps = go.GetComponent <PlayerScript> ();

		ps.SetTeamId = PhotonNetwork.countOfPlayersInRooms;

		if ( PhotonNetwork.countOfPlayersInRooms % 2 == 0 )
		{
			//TODO
		}
		*/
	}

	private void OnGUI ()
	{
		GUILayout.Label ( PhotonNetwork.connectionStateDetailed.ToString() );
	}

}