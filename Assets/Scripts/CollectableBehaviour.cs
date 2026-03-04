using UnityEngine;
using Game.Collectables;

public class CollectableBehaviour : MonoBehaviour{
    private GameController game;
  
    public CollectableType type = CollectableType.Coin;

    void Start(){
        game = GameController.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision);

        if (collision.gameObject.CompareTag("Player")){
            
            Debug.Log("Player collided");
    
            // game.HandleCollectableCapture(type);
            GameObject.Destroy(gameObject);
        }
    }
}
