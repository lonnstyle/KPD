using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }//check if it is self character
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        // Move the player character
        controller.Move(horizontalMove, verticalMove);
    }
}
