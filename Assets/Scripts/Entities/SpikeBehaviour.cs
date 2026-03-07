using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{

    private GameController _gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        _gameController = GameController.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Player")){
            _gameController.HandleHit();

            Rigidbody2D rig = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 normal = collision.contacts[0].normal;

            Debug.Log(normal);

            rig.AddForce(normal * -10f, ForceMode2D.Impulse);
        }
    }
}
