using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{    
    public TextMeshPro timeText;
    public Sprite lifeSprite;
    public Sprite spentLifeSprite;
    public UnityEngine.UIElements.Image[] livesImages;

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
        time = PlayerPrefs.GetInt("TimeToWin");
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
