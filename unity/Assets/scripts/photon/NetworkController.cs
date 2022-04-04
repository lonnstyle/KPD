using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
public class NetworkController : MonoBehaviourPunCallbacks
{   //[SerializeField] 
    //private TMP_InputField playerNameInput;
    //[SerializeField] 
    //private Text playerNameLabel;
   // private bool isPlayerNameChanging;
    // Documentation: https://doc.photonengine.com/en-us/pun/current/getting-started/pun-intro
    // Scripting API: https://doc-api.photonengine.com/en/pun/v2/index.html
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon master servers
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("[PUN2] Connected to " + PhotonNetwork.CloudRegion + " server!");
    }

   /* public void OnChangePlayerNamePressed(){
        if (isPlayerNameChanging == false){
            playerNameInput.text = playerNameLabel.text;
            playerNameLabel.GameObject.SetActive(false);
            playerNameInput.GameObject.SetActive(true);
            isPlayerNameChanging = true;
        }
        else {
            //if to check for empty or very long name
            if (string.IsNullOrEmpty(playerNameInput.text) == false && playerNameInput.text.Length <= 12){
                playerNameLabel.text = playerNameInput.text;
                PhotonNetwork.LocalPlayer.NickName = playerNameInput.text;
                photonView.RPC("UpdatePlayerUpdate", RPCTarget.All);
            }
            playerNameLabel.gameObject.SetActive(true);
            playerNameInput.gameObject.SetActive(false);
            isPlayerNameChanging = false;
        }
    }
    [PunRPC]
    public void ForcePlayerListUpdate(){
        UpdatePlayerList();
    }  */
    // Update is called once per frame
    void Update()
    {

    }
}
