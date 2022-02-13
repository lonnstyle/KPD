using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keypadTask : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _cardCode;
    public Text _inputCode;
    public float _codeResetTimeInSeconds = 0.5f;
    public int _codeLength = 4;
    public bool _isResetting = false;

    private void OnEnable() {
        string code = string.Empty;

        for (int i =0; i<_codeLength;i++) {
            code += Random.Range(1,10);
        }
        _cardCode.text = code;
        _inputCode.text = string.Empty;
    }
    public void ButtonClick(int number){
        if (_isResetting){
            return;
            }
            _inputCode.text += number;
        if(_inputCode.text == _cardCode.text){
            _inputCode.text = "correct";
            StartCoroutine(ResetCode());
            main.Instance.SwitchChange(1);
        }
        else if (_inputCode.text.Length >= _codeLength){
            _inputCode.text = "Failed";
            StartCoroutine(ResetCode());
        }
    }

    private IEnumerator ResetCode(){
        _isResetting = true;

        yield return new WaitForSeconds(_codeResetTimeInSeconds);

        _inputCode.text = string.Empty;
        _isResetting = false;
    }
    // Update is called once per frame

}
