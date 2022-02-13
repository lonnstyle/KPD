using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSay : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] lightArray;
    [SerializeField] GameObject[] rowLights;
    [SerializeField] int[] lightOrder;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject Tasktext;
    int level = 0;
    int buttonsclicked = 0;
    int colorOrderRunCount;
    bool _ispassed = false;
    bool _iswon = false;

    Color32 red = new Color32(255, 39, 0, 255);
    Color32 green = new Color32(4, 204, 0, 255);
    Color32 invisible = new Color32(4, 204, 0, 0);
    Color32 white = new Color32(255, 255, 255, 255);

    public float lightspeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {       //once the game is enabled 
        level = 0;                  //the level will reset to 0
        buttonsclicked = 0;
        colorOrderRunCount = -1;
        _iswon = false;
        for (int i = 0; i < lightOrder.Length; i++)
        {
            lightOrder[i] = (Random.Range(0, 8));
            Debug.Log("for loop" + lightOrder[i]);
        }
        for (int i = 0; i < rowLights.Length; i++)
        {
            rowLights[i].GetComponent<Image>().color = white;
            //Debug.Log("for loop" + rowLights[i]);
        }
        level = 1;
        StartCoroutine(ColorOrder());
    }

    public void ButtonClickOrder(int button)
    {
        //Debug.Log(lightOrder[button]+"this is the button value" +button);

        buttonsclicked++;
        if (button == lightOrder[buttonsclicked - 1])
        {
            Debug.Log("pass");
            _ispassed = true;
        }
        else
        {
            Debug.Log("failed");
            _iswon = false;
            _ispassed = false;
            StartCoroutine(ColorBlink(red));
        }
        if (buttonsclicked == level && _ispassed == true && buttonsclicked != 5)
        {
            level++;
            _ispassed = false;
            StartCoroutine(ColorOrder());
        }
        if (buttonsclicked == level && _ispassed == true && buttonsclicked == 5)
        {
            Debug.Log("failed");
            _iswon = true;
            main.Instance.SwitchChange(1);
            StartCoroutine(ColorBlink(green));
        }
    }
    public void ClosePanel()
    {
        GamePanel.SetActive(false);
    }
    public void OpenPanel()
    {
        GamePanel.SetActive(true);
    }
    IEnumerator ColorBlink(Color32 colorToBlink)
    {
        for (int j = 0; j < 3; j++)
        {
            Debug.Log("I run this many times" + j);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = colorToBlink;
            }
            for (int i = 5; i < buttons.Length; i++)
            {
                rowLights[i].GetComponent<Image>().color = colorToBlink;
            }

            yield return new WaitForSeconds(.5f); //after the image change to another color
            //force wait for 0.5 seconds

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = white;
            }
            for (int i = 5; i < rowLights.Length; i++)
            {
                rowLights[i].GetComponent<Image>().color = white;
            }

            yield return new WaitForSeconds(.5f);
        }
        if (_iswon)
        {
            Tasktext.SetActive(false);
            ClosePanel();
        }
        EnableInteractableButtons();
        OnEnable();
    }
    IEnumerator ColorOrder()
    {
        buttonsclicked = 0;
        colorOrderRunCount++;
        DisableInteractableButtons();
        for (int i = 0; i <= colorOrderRunCount; i++)
        {
            if (level >= colorOrderRunCount)
            {
                Debug.Log(lightOrder[0]);
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                yield return new WaitForSeconds(lightspeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = green;
                yield return new WaitForSeconds(lightspeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                rowLights[i].GetComponent<Image>().color = green;
            }
        }
        EnableInteractableButtons();
    }
    void DisableInteractableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }
    void EnableInteractableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
}
