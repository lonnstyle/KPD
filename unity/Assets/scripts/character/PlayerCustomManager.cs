using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomManager : MonoBehaviourPun
{
    [SerializeField] SpriteRenderer playerRenderer;
    private float[] colors = { 0f, 0f, 0f };

    void Start()
    {   
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        colors[0] = PlayerPrefs.GetFloat("characterColorR");
        colors[1] = PlayerPrefs.GetFloat("characterColorG");
        colors[2] = PlayerPrefs.GetFloat("characterColorB");
        Color newColor = new Color(colors[0], colors[1], colors[2]);
        playerRenderer.color = newColor;
        Debug.Log(newColor.ToString());
        Debug.Log(colors.ToString());
    }
}
