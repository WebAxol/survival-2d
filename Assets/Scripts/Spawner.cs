using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;

    public float maxHeight;
    public float minHeight;
    public float minTimeToSpawn;
    public float maxTimeToSpawn;

    void Start(){
        StartCoroutine(SpawnerTime());
    }

    IEnumerator SpawnerTime(){
        yield return new WaitForSeconds(Random.Range(minTimeToSpawn, maxTimeToSpawn));

        Instantiate(spawnable, new Vector3(
            transform.position.x, 
            transform.position.y + Random.Range(minHeight, maxHeight), 0), Quaternion.identity
        );

        StartCoroutine(SpawnerTime());
    }
}
