using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject JoinButton; //button used for joining a game.
    [SerializeField]
    private GameObject CancelButton; //button used to stop searing for a game to join.
    [SerializeField]
    private int RoomSize; //Manual set the number of player in the room at one time.
    [SerializeField]
    private GameObject LoadingButton;
    // Start is called before the first frame update
    public override void OnConnectedToMaster() //callback function for when the first connection is eased
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        JoinButton.SetActive(true);
        LoadingButton.SetActive(false);
        Debug.Log("Ready!");
    }

    public void Join() //paired to the join button
    {
        JoinButton.SetActive(false);
        CancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); //First try to join an existing room
        Debug.Log("Attemping to join Photon game room.");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //callback function for failed to join a room
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    void CreateRoom() //try to host a game room
    {
        Debug.Log("Creating a game room.");
        int randomRoomNumber = Random.Range(0, 10000); //create a random room number 
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //attempting to create a new game room
        Debug.Log("New room number:" + randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) //callback function for failed to create room
    {
        Debug.Log("Failed to create room... try again...");
        Debug.Log(message);
        CreateRoom(); //try again to recreate the room, with re-generated room name
        // most likely failed to create becuz of existing room name, which should update CreateRoom() in the future for optimization
        //TODO: we should add a max retry for that, but shouldn't be a case for dev build, ignore for now
    }

    public void Cancel() //paired to cancel button
    {
        CancelButton.SetActive(false);
        JoinButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
        Debug.Log("Cancelled ");
    }
}
