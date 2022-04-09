using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using System;

public class PlayerMovement : MonoBehaviour, IPunObservable
{
    [SerializeField] bool hasControl;
    public static PlayerMovement localPlayer;
    VentsSystem VentsSystem;
    //Components
    Rigidbody myRB;
    Transform myAvatar;
    Animator myAnim;

    //Player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    float direction = 1;
    //Player Color
    static Color myColor;
    SpriteRenderer myAvatarSprite;

    //Role
    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;

    List<PlayerMovement> targets;
    PlayerMovement target;
    [SerializeField] Collider myCollider;

    bool isDead;
    [SerializeField] GameObject bodyPrefab;

    public static List<Transform> allBodies;
    List<Transform> bodiesFound;

    [SerializeField] InputAction REPORT;
    [SerializeField] LayerMask ignoreForBody;

    //Interaction
    [SerializeField] InputAction MOUSE;
    Vector2 mousePositionInput;
    Camera myCamera;
    [SerializeField] InputAction INTERACTION;
    [SerializeField] LayerMask interactLayer;

    //Networking
    PhotonView myPV;
    [SerializeField] GameObject lightMask;
    // [SerializeField] lightcaster myLightCaster;
    float TimeLeft = 0;
    private void Awake()
    {
        KILL.performed += KillTarget;
        REPORT.performed += ReportBody;
        INTERACTION.performed += Interact;
    }

    private void OnEnable()
    {
        WASD.Enable();
        KILL.Enable();
        REPORT.Enable();
        MOUSE.Enable();
        INTERACTION.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
        KILL.Disable();
        REPORT.Disable();
        MOUSE.Disable();
        INTERACTION.Disable();
    }

    private void Start()
    {
        myPV = GetComponent<PhotonView>();

        if (myPV.IsMine)
            localPlayer = this;

        myCamera = transform.GetChild(1).GetComponent<Camera>();
        targets = new List<PlayerMovement>();
        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);
        myAnim = GetComponent<Animator>();
        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();

        if (!myPV.IsMine)
        {
            myCamera.gameObject.SetActive(false);
            //lightMask.SetActive(false);
            // myLightCaster.enabled = false;
            return;
        }
        if (myColor == Color.clear)
            myColor = Color.white;

        myAvatarSprite.color = myColor;

        allBodies = new List<Transform>();
        bodiesFound = new List<Transform>();
    }

    private void Update()
    {
        myAvatar.localScale = new Vector2(direction, 1);

        if (!myPV.IsMine)
            return;

        movementInput = WASD.ReadValue<Vector2>();
        myAnim.SetFloat("Speed", movementInput.magnitude);

        if (movementInput.x != 0)
        {
            direction = Mathf.Sign(movementInput.x);
        }

        if (allBodies.Count > 0)
        {
            BodySearch();
        }

        if (REPORT.triggered)
        {
            if (bodiesFound.Count == 0)
                return;
            Transform tempBody = bodiesFound[bodiesFound.Count - 1];
            allBodies.Remove(tempBody);
            bodiesFound.Remove(tempBody);
            tempBody.GetComponent<Body>().Report();
        }

        mousePositionInput = MOUSE.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!myPV.IsMine)
            return;
        myRB.velocity = movementInput * movementSpeed;
    }

    public void SetColor(Color newColor)
    {
        myColor = newColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }

    public void SetRole(bool newRole)
    {
        isImposter = newRole;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement tempTarget = other.GetComponent<PlayerMovement>();

            if (isImposter)
            {
                if (tempTarget.isImposter)
                    return;
                else
                    targets.Add(tempTarget);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement tempTarget = other.GetComponent<PlayerMovement>();
            if (targets.Contains(tempTarget))
            {
                targets.Remove(tempTarget);
            }
        }
    }

    private void KillTarget(InputAction.CallbackContext context)
    {
        if (!myPV.IsMine)
            return;
        if (!isImposter)
            return;
        if (TimeLeft > 0)
            return;
        if (context.phase == InputActionPhase.Performed)
        {
            if (targets.Count == 0)
                return;
            else
            {
                if (targets[targets.Count - 1].isDead)
                    return;

                transform.position = targets[targets.Count - 1].transform.position;
                targets[targets.Count - 1].Die();
                targets[targets.Count - 1].myPV.RPC("RPC_Kill", RpcTarget.All);
                targets.RemoveAt(targets.Count - 1);
                StartCoroutine(Killtime());
            }
        }
    }

    [PunRPC]
    void RPC_Kill()
    {
        Die();
    }

    public void Die()
    {
        if (!myPV.IsMine)
            return;

        Body tempBody = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Body"), transform.position, transform.rotation)
            .GetComponent<Body>();
        tempBody.SetColor(myAvatarSprite.color);

        isDead = true;

        myAnim.SetBool("Dead", isDead);
        gameObject.layer = 10;
        myCollider.enabled = false;
    }

    void BodySearch()
    {
        foreach (Transform body in allBodies)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, body.position - transform.position);
            Debug.DrawRay(transform.position, body.position - transform.position, Color.cyan);
            if (Physics.Raycast(ray, out hit, 1000f, ~ignoreForBody))
            {
                if (hit.transform == body)
                {
                    // Debug.Log(hit.transform.name);
                    // Debug.Log(bodiesFound.Count);
                    if (bodiesFound.Contains(body.transform))
                        return;
                    bodiesFound.Add(body.transform);
                }
                else
                {
                    bodiesFound.Remove(body.transform);
                }
            }

        }
    }

    private void ReportBody(InputAction.CallbackContext obj)
    {
        if (bodiesFound == null)
            return;
        if (bodiesFound.Count == 0)
            return;
        Transform tempBody = bodiesFound[bodiesFound.Count - 1];
        allBodies.Remove(tempBody);
        bodiesFound.Remove(tempBody);
        tempBody.GetComponent<Body>().Report();
    }

    void Interact(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(mousePositionInput);
            if (Physics.Raycast(ray, out hit, interactLayer))
            {
                if (hit.transform.tag == "Interactable")
                {
                    if (!hit.transform.GetChild(0).gameObject.activeInHierarchy)
                        return;
                    Interactable temp = hit.transform.GetComponent<Interactable>();
                    temp.PlayMiniGame();
                }
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(direction);
            stream.SendNext(isImposter);
        }
        else
        {
            this.direction = (float)stream.ReceiveNext();
            this.isImposter = (bool)stream.ReceiveNext();
        }
    }

    public void BecomeImposter(int ImposterNumber)
    {
        if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[ImposterNumber])
            isImposter = true;
    }
    public void KillPlayer()
    {
        myAnim.SetTrigger("Dead");
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
    #region Vent Movement Control
    public void EnterVent(VentsSystem ventsSystem)
    {
        this.VentsSystem = ventsSystem;

        //Animation and sounds
        //playerAnimator.SetTrigger("Vent");
        //playerAudioController.StopWalking();
        //playerAudioController.PlayVent();
    }

    public void VentEntered()
    {
        DisablePlayer();

        VentsSystem.PlayerInVent();
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
    #endregion Change Player Properties

    private IEnumerator Killtime()
    {
        TimeLeft = 30;
        while (TimeLeft != 0)
        {
            yield return new WaitForSeconds(1);
            TimeLeft--;
            Debug.Log("kill time reset remain:"+ TimeLeft);
        }
    }


}

