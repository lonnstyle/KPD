using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomManager : MonoBehaviour
{
    [SerializeField] Button colorButton;
    // color list: [white, lime, emerald, cyan, indigo, violet, magenta, red, amber, yellow, steel, taupe]
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("characterColor"))
        {
            PlayerPrefs.SetString("characterColor", new Color(0f, 0f, 0f, 0f).ToString());
        }
        Load();
    }

    public void ChangeColor()
    {
        Save();
    }

    private void Load()
    {
        if (colorButton.colors.normalColor.ToString() == PlayerPrefs.GetString("characterColor"))
        {
            // colorButton.enabled = true;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("characterColorR", colorButton.colors.normalColor.r);
        PlayerPrefs.SetFloat("characterColorG", colorButton.colors.normalColor.g);
        PlayerPrefs.SetFloat("characterColorB", colorButton.colors.normalColor.b);
        Debug.Log(colorButton.colors.normalColor.ToString());
    }
}
