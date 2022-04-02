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
            PlayerPrefs.SetFloat("characterColorR", 1f);
            PlayerPrefs.SetFloat("characterColorG", 1f);
            PlayerPrefs.SetFloat("characterColorB", 1f);
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
             //colorButton.enabled = true;
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
