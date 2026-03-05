using UnityEngine;

public class ViewportDespawnController : MonoBehaviour{

    public Spawnable _spawnable; 

    void Update(){        

        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        Vector3 pos = transform.position + new Vector3(halfWidth,0f,0f);

        if(Camera.main.WorldToViewportPoint(pos).x < 0) _spawnable.Despawn();
    }
}
