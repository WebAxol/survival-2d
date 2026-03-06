using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instantiates a given game-object or prefab based on internal conditions.
/// It handles the deactivation of gameobjects and their reutilization.
/// </summary>
public class Spawner : MonoBehaviour{

    public GameObject prefab;
    protected List<GameObject> activeObjects = new List<GameObject>();
    protected List<GameObject> pool = new List<GameObject>(); 

    public float maxActive = 5;

    void Start(){}

    protected Vector3 SetupPosition(){
        return new Vector3(
            transform.position.x,
            transform.position.y,
            1f
        );
    }

    protected GameObject Spawn(){
        
        GameObject obj;

        // if(pool.Count > 0){
        //     return ReturnFromPool();
        // }

        obj = Instantiate(
            prefab,
            SetupPosition(),
            Quaternion.identity
        );

        var spawnable = obj.GetComponent<Spawnable>();
        
        if(spawnable == null){ 
            spawnable = obj.AddComponent<Spawnable>();
        }

        spawnable.SetSpawner(this);

        activeObjects.Add(obj);

        return obj;
    }

    protected GameObject ReturnFromPool(){

        var recycled = pool[0];
        
        recycled.transform.position = SetupPosition();
        
        pool.RemoveAt(0);
        activeObjects.Add(recycled);

        return recycled;
    }

    protected void ReturnToPool(GameObject obj){

        if(obj == null) return;

        // obj.SetActive(false);
        // pool.Add(obj);
        activeObjects.Remove(obj);

        Destroy(obj);
    }

    public virtual void HandleDestroy(GameObject obj){

        if(obj == null) return;

        activeObjects.Remove(obj);
        pool.Remove(obj);
    }

    public virtual void HandleDespawn(GameObject obj){    
        ReturnToPool(obj);
    }
}
