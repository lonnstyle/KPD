using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sabotage : MonoBehaviour
{
    [SerializeField] GameObject SabotageButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ImposterFunc(PlayerMovement player)
    {   if(player.ImposterFunc = true)
        SabotageButton.SetActive(true);
    }
}
