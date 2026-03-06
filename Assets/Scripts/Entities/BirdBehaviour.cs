using UnityEngine;

public class BirdBehaviour : MonoBehaviour{

    public Spawnable _spawnable; 
    private GameController _gameController;

    public float speed;

    public void Start(){
        _spawnable = GetComponent<Spawnable>();
        _gameController = GameController.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Player")){
            _spawnable.Despawn();
            _gameController.HandleHit();
        }
    }

    void Update(){
        this.transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
