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

    public float offsetX = 0;
    public float offsetY = 0;
    public float maxActive = 5;

    void Start(){}

    protected Vector3 SetupPosition(Transform transform){
        return new Vector3(
            transform.position.x,
            transform.position.y,
            1f
        );
    }

    protected GameObject Spawn(){
        
        GameObject obj;

        if(pool.Count > 0){
            return ReturnFromPool();
        }

        obj = Instantiate(
            prefab,
            SetupPosition(transform),
            Quaternion.identity
        );

        var spawnable = obj.GetComponent<Spawnable>();
        
        if(spawnable == null){ 
            spawnable = obj.AddComponent<Spawnable>();
        }

        spawnable.SetSpawner(this);

        activeObjects.Add(obj);

        obj.SetActive(true);

        return obj;
    }

    protected GameObject ReturnFromPool(){

        var recycled = pool[0];
        
        recycled.transform.position = SetupPosition(transform);
        
        pool.RemoveAt(0);
        activeObjects.Add(recycled);
        recycled.SetActive(true);

        return recycled;
    }

    protected void ReturnToPool(GameObject obj){

        if(obj == null) return;

        obj.SetActive(false);
        pool.Add(obj);
        activeObjects.Remove(obj);
    }

    public virtual void HandleDestroy(GameObject obj){

        activeObjects.Remove(obj);
        pool.Remove(obj);
    }

    public virtual void HandleDespawn(GameObject obj){
    
        int n = activeObjects.Count;

        if(activeObjects.IndexOf(obj) == 0){

        }
        else if(activeObjects.IndexOf(obj) == n - 1){
            
        }
    
        ReturnToPool(obj);
    }
}
