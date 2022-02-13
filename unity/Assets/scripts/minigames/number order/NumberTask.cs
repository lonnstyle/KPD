using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberTask : MonoBehaviour
{   
    [SerializeField] private List<NumberButtons> _buttonList = new List<NumberButtons>();
    [SerializeField] GameObject Tasktext;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject _FailedText;
    private int currentValue;

    private void OnEnable() {
        List<int> numbers = new List<int>();

        for (int i =0; i<_buttonList.Count; i++)
        {
            numbers.Add(i+1);
        }

        for (int i =0; i<_buttonList.Count; i++)
        {
            int pickedNumber = numbers[Random.Range(0,numbers.Count)];
            //initizlize button and random all
            _buttonList[i].Initialize(pickedNumber,this);
            numbers.Remove(pickedNumber);
        }
        currentValue = 1;
    }
    private void ResetButtons() {
        foreach (NumberButtons buttons in _buttonList)
        {
            buttons.ToggleButton(true);
        }
    }
    public void OnButtonPressed(int buttonID, NumberButtons currentButton)
    {   //Check if the correct button
        if(currentValue >= _buttonList.Count)
        {   
            
            Debug.Log("task done");
            StartCoroutine(ClosePanel(GamePanel)); 
            
            
        }
        if (currentValue == buttonID)
        {
            currentValue++;
            currentButton.ToggleButton(false);
        }
        else
        {
            currentValue = 1;
            ResetButtons();
            StartCoroutine(PanelFailed(_FailedText));
            Debug.Log("task not done");
        }
    }
    IEnumerator ClosePanel(GameObject panel)
    {   
        for (int i =0; i<3;i++)
        {
        Tasktext.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Tasktext.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        }
        GamePanel.SetActive(false);
        
    }
     IEnumerator PanelFailed(GameObject FailedText)
    {   
        for (int i =0; i<3;i++)
        {
        FailedText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        FailedText.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        }
    }
}
