using UnityEngine;

public class BirdBehaviour : MonoBehaviour{

    public Spawnable _spawnable; 

    public float speed;

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Player")){
            _spawnable.Despawn();
        }
    }

    void Update(){
        this.transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
