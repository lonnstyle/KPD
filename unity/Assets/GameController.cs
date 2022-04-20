using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private PhotonView myPv;

    private int whichPlayerIsImposter;

    public static GameController instance;
    public int totalplayer;
    public bool numberTaskCompleted;

    private int TaskCount;
    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        myPv = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            PickImposter();
        }
    }

    private void PickImposter()
    {
        totalplayer = PhotonNetwork.CurrentRoom.PlayerCount;
        whichPlayerIsImposter = Random.Range(1, PhotonNetwork.CurrentRoom.PlayerCount);
        myPv.RPC(nameof(RPC_SyncImposter), RpcTarget.All, whichPlayerIsImposter);
        Debug.Log("Imposter " + whichPlayerIsImposter);
        Debug.Log("Total player:" + totalplayer);    
    }

    [PunRPC]
    void RPC_SyncImposter(int playerNumber)
    {
        whichPlayerIsImposter = playerNumber;
        PlayerMovement.localPlayer.BecomeImposter(whichPlayerIsImposter);
    }

    public void CompleteNumberTask()
    {
        numberTaskCompleted = true;
        myPv.RPC(nameof(RPC_CompleteNumberTask), RpcTarget.All, numberTaskCompleted);
    }

    [PunRPC]
    void RPC_CompleteNumberTask(bool isCompleted)
    {
        numberTaskCompleted = isCompleted;
        TaskCount++;
        Debug.Log(TaskCount);
    }
    
}