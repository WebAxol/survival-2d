using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour {

    public TextMeshProUGUI panelText;
    public TextMeshProUGUI scoreText;

    public GameObject ninaSprite;
    public SFXManager sfxManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
        if(PlayerPrefs.GetInt("Birds", 0) >= PlayerPrefs.GetInt("BirdsToWin", 5))
        {
            TriggerWinAnimation();
            panelText.text = "You Won!";
            sfxManager.PlayWinSound();
        }
        else
        {
            TriggerDeathAnimation();
            panelText.text = "You Lost!";
            sfxManager.PlayDeathSound();
        }

        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }

    
    public void TriggerWinAnimation(){

        Debug.Log(ninaSprite);

        ninaSprite.GetComponent<Animator>().SetTrigger("hasWon");
    }

    public void TriggerDeathAnimation(){

        Debug.Log(ninaSprite);


        ninaSprite.GetComponent<Animator>().SetTrigger("isDead");
    }

    void Update()
    {
        
    }
}
