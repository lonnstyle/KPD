using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayernameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField username;

    public void ChangePlayername()
    {
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetString("username", username.text);
        PhotonNetwork.NickName = username.text;
    }
}
