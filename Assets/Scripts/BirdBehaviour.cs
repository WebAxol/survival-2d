using UnityEngine;

public class BirdBehaviour : MonoBehaviour{

    public float speed;

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Player")){
            GameObject.Destroy(this.gameObject);
        }
    }

    void Update(){
        this.transform.position += Vector3.left * Time.deltaTime * speed;
        if(transform.position.x < -50) GameObject.Destroy(this.gameObject);
    }
}
