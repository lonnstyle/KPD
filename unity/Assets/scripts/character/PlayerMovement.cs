using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Realtime;
namespace Com.MyCompany.MyGame{
public class PlayerMovement : MonoBehaviourPun
    {   PhotonView myPV;
        GameObject myPlayerAvatar;

        Player[] allPlayers;
        int myNumberInRoom;

        public CharacterController2D controller;
        float horizontalMove = 0f;
        float verticalMove = 0f;
        private Rigidbody2D m_Rigidbody2D;

        private bool collidePlayer = false;
        public GameObject otherPlayer;
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {   

            CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();


        if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
        }
        }

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
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
                Debug.Log("I'm trying to kill someone" + otherPlayer);
                // otherPlayer.SendMessage("killed");
                otherPlayer.GetComponent<PlayerMovement>().killed();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "player(Clone)")
            {
                collidePlayer = true;
                otherPlayer = other.gameObject;
                Debug.Log(otherPlayer);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            collidePlayer = false;
            // otherPlayer = null;
        }

        void FixedUpdate()
        {
            // Move the player character
            controller.Move(horizontalMove, verticalMove);
        }

        public void killed()
        {
            Debug.Log("I'm dead" + this.name);
            animator.SetBool("Dead", true);
        }
    }
}