using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumpadButtonController : MonoBehaviour {

    public enum FUNCTION
    {
        NUMBER,
        CLEAR
    }

    public delegate void KeyPress(NumpadButtonController button);
    public static event KeyPress KeyPressed;

    public string Number;
    public FUNCTION Function;

	// Use this for initialization
	void Start () {
        gameObject.transform.Find("Text").GetComponent<Text>().text = Number;
	}
	
	public void OnButtonClick()
    {
        if (KeyPressed != null)
            KeyPressed(this);
    }
}

