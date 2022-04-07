using Photon.Pun;
using UnityEngine;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex;//Number for the build index to multiplayer scene

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom() //callback of joined a room successfully
    {
        Debug.Log("Joined Room");
        StartGame();
    }

    private void StartGame() //function for loading into multiplayer scene.
    {
        if (PhotonNetwork.IsMasterClient) //MasterClient => host
        //TODO: we should separate join/host in the future, and only the host should be able to StartGame, without using an if statement.
        {
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex); //due to AutomaticallySyncScene, all player should load the level together.
        }
    }
}
