using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int P1score = 0;
    public int P2score = 0;
    public Text P1scoreText;
    public Text P2scoreText;
    public Text START;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        START.text = "press key to play";
        P1scoreText.text = P1score.ToString();
        P2scoreText.text = P2score.ToString();
        

    }

    public void pressedKey()
    {
        if (Input.anyKey)
        {
            START.text = "";
        }
    }

    public void P1reset()
    {
        P1score = 0;
        P1scoreText.text = P1score.ToString();
    }

    public void P2reset()
    {
        P2score = 0;
        P2scoreText.text = P2score.ToString();
    }
    public void addPointP1()
    {
        P1score++;
        P1scoreText.text = P1score.ToString();
    }
    public void addPointP2()
    {
        P2score++;
        P2scoreText.text = P2score.ToString();
    }
}