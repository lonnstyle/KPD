using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    static public main Instance;

    public int Count;
    public GameObject doneText;
    private int onCount = 0;
    // Start is called before the first frame update
    private void Awake() 
    {  
        Instance = this;
    }
    public void SwitchChange(int points)
    {
        onCount = onCount + points;
        if (onCount == Count){
            doneText.SetActive(true);
        }
    }
}

