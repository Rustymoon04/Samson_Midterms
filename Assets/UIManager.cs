using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text eggText;
    public Text chickText;
    public Text henText;
    public Text roosterText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        eggText.text = "Eggs: " + gameManager.eggCount;
        chickText.text = "Chicks: " + gameManager.chickCount;
        henText.text = "Hens: " + gameManager.henCount;
        roosterText.text = "Roosters: " + gameManager.roosterCount;
    }
}