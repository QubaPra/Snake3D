using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Color wantedColor;
    public ButtonColorChange button;
    private ColorBlock colors;

    // Start is called before the first frame update
    void ChangeButtonCollor()
    {
        ColorBlock cb = button.colors;
        cb.normalColor = wantedColor;
        cb.highlightedColor = wantedColor;
        cb.pressedColor = wantedColor;
        button.colors= cb;
    }
}

