using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class game_switch : MonoBehaviour
{
    public GameObject on;
    public bool ison;
    // Start is called before the first frame update
    void Start()
    {
        on.SetActive(ison);
        if (ison) 
        {
            main.Instance.SwitchChange(1);
        }
    }

    // Update is called once per frame
    private void OnMouseUp() {
        ison = !ison;
        on.SetActive(ison);
        if (ison){
            main.Instance.SwitchChange(1);
        }   
        else {
            main.Instance.SwitchChange(-1);
        }
    }
}
