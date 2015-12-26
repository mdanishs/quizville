using UnityEngine;
using System.Collections;

public class NumpadController : MonoBehaviour {

    public string Text {
        get
        {
            return _string;
        }
    }

    private string _string;

    // Use this for initialization
    void Start () {
        _string = "";
        NumpadButtonController.KeyPressed += NumpadButtonController_KeyPressed;
	}

    private void NumpadButtonController_KeyPressed(NumpadButtonController button)
    {
        if (button.Function == NumpadButtonController.FUNCTION.CLEAR)
        {
            if(_string.Length > 0)
                _string = _string.Substring(0, _string.Length - 1);
        }
        else
            _string += button.Number;
    }

    public void Update()
    {
        
    }

    public void ClearText()
    {
        _string = "";
    }

}
