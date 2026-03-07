using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public UIController uiController;
    static public GameController Instance;
    public SFXManager sfxManager;
    bool gameEnded = false;


    public void Awake()
    {
        PlayerPrefs.SetFloat("TimeToWin", 25);
        PlayerPrefs.SetInt("Lives",3);
        PlayerPrefs.SetInt("Score",0);

        Instance = this;
        Instance.SetReferences();
        // DontDestroyOnLoad(gameObject);
    }
    
    void SetReferences()
    {
        if(uiController == null) uiController = FindAnyObjectByType<UIController>(); 
        if(sfxManager == null)   sfxManager = FindAnyObjectByType<SFXManager>();

        var timeToWin = PlayerPrefs.GetInt("TimeToWin");

        sfxManager.PlayBackgroundSound();

        init();
    }

    void init(){
        if (uiController) uiController.Update();
    }


    void Update(){
        float time = PlayerPrefs.GetFloat("TimeToWin");
        PlayerPrefs.SetFloat("TimeToWin", time - Time.deltaTime);

        if(time <= 0 && !gameEnded){ 
            gameEnded = true;
            SceneManager.LoadScene("EndScene");
        }
    }

    public int GetCurrentLives()
    {
        return PlayerPrefs.GetInt("Lives");
    }

    private void SpendLives()
    {
        int lives = GetCurrentLives() - 1;
        PlayerPrefs.SetInt("Lives", lives);
        uiController.Update();

        if(lives == 0 && !gameEnded){ 
            gameEnded = true;
            SceneManager.LoadScene("EndScene");
        }
    }

    public void HandleHit(){
        SpendLives();
        sfxManager.PlayHitSound();
    }


    public void HandleCollect(){
        
        int score = PlayerPrefs.GetInt("Score") + 10;

        PlayerPrefs.SetInt("Score", score);

        sfxManager.PlayCollectableSound();
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }
}   
