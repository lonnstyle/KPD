using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class myPhotonPlayer : MonoBehaviour
{
    PhotonView myPV;
    GameObject myPlayerAvatar;

    Player[] allPlayers;
    int myNumberInRoom = 0;

    void Start()
    {
        myPV = GetComponent<PhotonView>();

        allPlayers = PhotonNetwork.PlayerList;
        foreach (Player p in allPlayers)
        {
            if (p != PhotonNetwork.LocalPlayer)
                myNumberInRoom++;
        }

        if (myPV.IsMine)
        {
            myPlayerAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "player"), SpawnPoints.instance.spawnPoints[myNumberInRoom].position, Quaternion.identity);
        }
    }

}