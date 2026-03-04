using UnityEngine;

public class GameController : MonoBehaviour
{

    public UIController uiController;
    static public GameController Instance;

    public void Awake()
    {
        PlayerPrefs.SetInt("TimeToWin", 15);
        PlayerPrefs.SetInt("Lives",3);

        Instance = this;
        Instance.SetReferences();
        DontDestroyOnLoad(gameObject);
    }

    void SetReferences()
    {
        if(!uiController) uiController = FindAnyObjectByType<UIController>(); 

        var timeToWin = PlayerPrefs.GetInt("TimeToWin");

        init();
    }

    void init(){
        if (uiController) uiController.Update();
    }

    public int GetCurrentLives()
    {
        return PlayerPrefs.GetInt("Lives");
    }

    public void SpendLife()
    {
        int lives = GetCurrentLives() - 1;
        PlayerPrefs.SetInt("Lives", lives);
        uiController.Update();
    }
}   
