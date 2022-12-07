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

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        P1scoreText.text = P1score.ToString();
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