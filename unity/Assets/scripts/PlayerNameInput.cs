using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
public class PlayerNameInput : MonoBehaviour
{   
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button ConfirmButton = null;
    
    private const string PlayerPrefsNameKey = "PlayerName"; //

    private void Start() {
        SetUpUnputField();
    }
    private void SetUpUnputField(){
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)){
            return; 
        }   //first time open the game, it wont do anything
        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }
    public void SetPlayerName(string name){
        ConfirmButton.interactable = !string.IsNullOrEmpty(name);
        //if not empty , the button will on
    }
    public void SavePlayerName(){
        string playerName = nameInputField.text;

        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(PlayerPrefsNameKey,playerName);
    }
}
