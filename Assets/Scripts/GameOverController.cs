using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public TextMeshProUGUI panelText;
    public TextMeshProUGUI scoreText;

    public GameObject ninaSprite;
    public SFXManager sfxManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
        if(PlayerPrefs.GetInt("Lives", 0) > 0)
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
        ninaSprite.GetComponent<Animator>().SetTrigger("hasWon");
    }

    public void TriggerDeathAnimation(){
        ninaSprite.GetComponent<Animator>().SetTrigger("isDead");
    }

    public void PlayAgain(){
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }
}
