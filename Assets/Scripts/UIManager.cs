using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//public delegate void simpleFunction();

public sealed class UIManager {  // should be a singleton, either a ScriptableObject or a normal c# singleton

    private static UIManager instance = new UIManager();
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private GameObject userInterfaceObject;

    private UIManager()
    {
        userInterfaceObject = Object.Instantiate(Resources.Load<GameObject>("UserInterface"));

    }

    public void ShowText(string text)
    {
        userInterfaceObject.transform.FindChild("Text").GetComponent<Text>().text = text;
    }

    public void ShowButtons(string text)//, button functions);
    {
        userInterfaceObject.transform.FindChild("Text").GetComponent<Text>().text = text;
    }
}
