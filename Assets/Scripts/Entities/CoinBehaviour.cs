using UnityEngine;

public class CoinBehaviour : MonoBehaviour{

    private GameController _gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        _gameController = GameController.Instance;
    }

    private void OnTriggerEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Player")){
            _gameController.HandleCollect();
        }
    }
}
