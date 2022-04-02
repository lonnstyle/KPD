using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    private Rigidbody2D m_Rigidbody2D;

    private bool collidePlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (collidePlayer && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("I'm trying to kill someone");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidePlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        collidePlayer = true;
    }

    void FixedUpdate()
    {
        // Move the player character
        controller.Move(horizontalMove, verticalMove);
    }
}
