using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using System.IO;
using System;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour 
{
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    VentsSystem ventsSystem;
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
        [SerializeField] InputAction MOUSE;
        [SerializeField] InputAction KILL;
        [SerializeField] InputAction Dotask;
        [SerializeField] InputAction Report;
        [SerializeField] InputAction INTERACTION;
        [SerializeField] InputAction REPORT; 
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

    private void OnEnable()
    {
        REPORT.Enable();
        MOUSE.Enable();
        INTERACTION.Enable();
    }

    public void Move(float horizontal_move, float vertical_move)
    {
        // //only control the player if grounded or airControl is turned on

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontal_move * 4f, vertical_move * 4f);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (horizontal_move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontal_move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
        #region Vent Movement Control
    public void EnterVent(VentsSystem ventsSystem)
    {
        this.ventsSystem = ventsSystem;

        //Animation and sounds
        //playerAnimator.SetTrigger("Vent");
        //playerAudioController.StopWalking();
        //playerAudioController.PlayVent();
    }

    public void VentEntered()
    {
        DisablePlayer();

        ventsSystem.PlayerInVent();
    }

    public bool IsInVent()
    {
        return GetComponent<Rigidbody2D>().simulated;
    }

    public void VentExited()
    {
        EnablePlayer();

        //sounds
        //playerAudioController.PlayVent();
    }
    #region Change Player Properties

    /*void Interact(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(mousePositionInput);
            if(Physics.Raycast(ray, out hit, interactLayer))
            {
                if(hit.transform.tag == "Interactable")
                {
                    if (!hit.transform.GetChild(0).gameObject.activeInHierarchy)
                        return;
                    Interactable temp = hit.transform.GetComponent<Interactable>();
                    temp.PlayMiniGame();
                }
            }
        }
    }   */ 

    public void KillPlayer()
    {
        //playerAnimator.SetTrigger("Dead");
    }
    void DisablePlayer()
    {
        //Color c = playerSpriteRenderer.color;
        //c.a = 0;
        //playerSpriteRenderer.color = c;
        GetComponent<Rigidbody2D>().simulated = false;
        //playerAudioController.StopWalking();
    }
    void EnablePlayer()
    {
       // Color c = playerSpriteRenderer.color;
       // c.a = 1;
        //playerSpriteRenderer.color = c;
        GetComponent<Rigidbody2D>().simulated = true;
        //MovePlayer();
    }
    #endregion
    #endregion
}