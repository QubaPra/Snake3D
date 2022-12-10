using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class sINGLEPLAYERsTATS : MonoBehaviour
{
    public static sINGLEPLAYERsTATS Instance;

    public int P1score = 0;
    public Text P1scoreText;
    public Text START;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        P1scoreText.text = P1score.ToString();


    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

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

    public void addPointP1()
    {
        P1score++;
        P1scoreText.text = P1score.ToString();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}