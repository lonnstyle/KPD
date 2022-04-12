using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject currentPanel;
    [SerializeField] GameObject nextpanel;
    [SerializeField] Transform NewPosition;
 
    public void ChangeVent()
    {
        currentPanel.SetActive(false);
        nextpanel.SetActive(true);
        PlayerMovement.localPlayer.transform.position = NewPosition.position;
    }
    // Update is called once per frame
    public void ExitVent()
    {
        currentPanel.SetActive(false);
     
    }
}
