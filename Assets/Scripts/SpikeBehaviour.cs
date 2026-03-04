using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
    private GameController game;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        game = GameController.Instance;
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        // if (collision.gameObject.CompareTag("Player"))
            // game.HandleGameOver();
    }
}
