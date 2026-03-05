using System.Collections;
using UnityEngine;

/// <summary>
/// Same as a regular spawner, but it creates a co-routine which
/// triggers Spawn() at regular intervals.
/// </summary>
public class TimedSpawner : Spawner
{
    public float delay = 3;

    void Start(){
        StartCoroutine(SpawnerTime());
    }

    /// <summary>
    /// Triggered Automatically by the Engine, when the Start() method is called.
    /// </summary>
    protected IEnumerator SpawnerTime(){

        while (true){
            yield return new WaitForSeconds(delay);
            if(activeObjects.Count < maxActive) Spawn();
        }
    }
}
