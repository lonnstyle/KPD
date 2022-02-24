using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class game_switch2 : MonoBehaviour
{   
    public GameObject Light;
    public GameObject Switch_on;
    public bool _isLighting;
    public bool Switch_ison;
    // Start is called before the first frame update
    void Start()
    {
        Switch_on.SetActive(Switch_ison);
        Light.SetActive(_isLighting);
        if (Switch_ison) 
        {
            main.Instance.SwitchChange(1);
        }
    }

    // Update is called once per frame
    private void OnMouseUp() {
        Switch_ison = !Switch_ison;
        _isLighting = !_isLighting;

        Switch_on.SetActive(Switch_ison);
        Light.SetActive(_isLighting);
        if (Switch_ison){
            main.Instance.SwitchChange(1);
        }   
        else {
            main.Instance.SwitchChange(-1);
        }
    }
}
