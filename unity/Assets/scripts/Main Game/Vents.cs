using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    [SerializeField]
    GameObject CurrentPanel;  //currentVent
    [SerializeField]
    GameObject nextPanel;   // next vent
    [SerializeField]
    Transform NewPosition;      // target position
    // Update is called once per frame
    public void ChangeVent()
    {
        {
            CurrentPanel.SetActive(false);
            nextPanel.SetActive(true);
            PlayerMovement.localPlayer.transform.position = NewPosition.position;
        }
    }
    public void ExitVent()  
    {
        CurrentPanel.SetActive(false); 
    }
}
