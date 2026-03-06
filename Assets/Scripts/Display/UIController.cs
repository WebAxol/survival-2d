using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{    
    public TextMeshProUGUI timeText;
    public Sprite lifeSprite;
    public Sprite spentLifeSprite;
    public Image[] livesImages;

    int lives = 3;
    int time  = 100;

    void Start()
    {   
        Update();
    }
      
    public void Update()
    {
        UpdateTime();
        UpdateLives();
    }

    public void UpdateTime()
    {
        float time = PlayerPrefs.GetFloat("TimeToWin");

        timeText.text = "Time left: " + Math.Floor(time).ToString();
    }

    public void UpdateLives()
    {
        lives = PlayerPrefs.GetInt("Lives");
        
        int maxLives = livesImages.Length;

        for(int i = 0; i < lives; i++){
            livesImages[i].sprite = lifeSprite;
        }
        for(int i = lives; i < maxLives; i++){
            livesImages[i].sprite = spentLifeSprite;
        }
    }
}
