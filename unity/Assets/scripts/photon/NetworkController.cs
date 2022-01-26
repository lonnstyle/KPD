using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
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

    // Update is called once per frame
    void Update()
    {

    }
}
