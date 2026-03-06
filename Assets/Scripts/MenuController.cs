using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{
    public void StartToPlay(){
        SceneManager.LoadScene("GameScene");
    }

    public void Exit(){
        Application.Quit();
    }
}
