using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    protected List<GameObject> activeObjects = new List<GameObject>();
    protected List<GameObject> pool = new List<GameObject>(); 

    public float offsetX;
    public float offsetY;
    public float maxActive;
    public float delay;

    void Start(){
        StartCoroutine(SpawnerTime());
    }

    protected virtual Vector3 SetupPosition(){
        return new Vector3(
            transform.position.x,
            transform.position.y,
            1f
        );
    }

    public GameObject Spawn(){
        
        GameObject obj;

        if(pool.Count > 0){
            return ReturnFromPool();
        }

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

        obj.SetActive(true);

        return obj;
    }

    protected GameObject ReturnFromPool(){

        var recycled = pool[0];
        
        recycled.transform.position = SetupPosition();
        
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

    public void HandleDestroy(GameObject obj){

        activeObjects.Remove(obj);
        pool.Remove(obj);
    }

    public void HandleDespawn(GameObject obj){
        ReturnToPool(obj);
    }

    IEnumerator SpawnerTime(){

        while (true){
            yield return new WaitForSeconds(delay);
            if(activeObjects.Count < maxActive) Spawn();
        }
    }
}
