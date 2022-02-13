using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtons : MonoBehaviour
{   
    private int _value;
    private Text _buttonText;
    private Button _button;
    private NumberTask _parentTask;

    public void Initialize(int value, NumberTask parentTask)
    {
        if(_buttonText == null)
        {
            _buttonText =  GetComponentInChildren<Text>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
        }
        _value = value;
        _buttonText.text = value.ToString();
        _parentTask = parentTask;
    }
    public void ToggleButton(bool isOn)
    {
        _button.interactable = isOn ;
    }
    private void OnButtonPressed()
    {
        _parentTask.OnButtonPressed(_value,this);
    }
}
