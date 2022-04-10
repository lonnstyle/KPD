using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class PlayerNameTag : MonoBehaviourPun
{   
    [SerializeField] 
    private TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine){
            return;
        }
        SetName();
    }

    // Update is called once per frame
    void SetName() => nameText.text = photonView.Owner.NickName;
}
