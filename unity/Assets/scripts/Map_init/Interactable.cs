using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame; //connect to minigame 
    GameObject highlight;

    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            highlight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            highlight.SetActive(false);
    }

    public void PlayMiniGame()
    {
        miniGame.SetActive(true);
    }

}