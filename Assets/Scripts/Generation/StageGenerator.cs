using UnityEngine;
using System.Linq;

/// <summary>
/// 
/// </summary>
public class StageGenerator : Spawner
{
    void Start()
    {
        for(int i = 0; i < maxActive; i++)
            SpawnRight();
    }

    float GetRightEdge(){
        return activeObjects.Max(obj => obj.GetComponent<Renderer>().bounds.max.x);
    }

    float GetLeftEdge(){
        return activeObjects.Min(obj => obj.GetComponent<Renderer>().bounds.min.x);
    }

    void SpawnRight(){
        GameObject chunk = Spawn();

        float halfWidth = chunk.GetComponent<Renderer>().bounds.extents.x;

        float x = GetRightEdge() + halfWidth;

        Debug.Log(x);

        chunk.transform.position = new Vector3(
            x,
            transform.position.y,
            transform.position.z
        );

        Debug.Log("ldwdw");

        chunk.SetActive(false);
        chunk.SetActive(true);
    }

    void SpawnLeft()
    {
        GameObject chunk = Spawn();

        float halfWidth = chunk.GetComponent<Renderer>().bounds.extents.x;

        float x = GetLeftEdge() - halfWidth;

        chunk.transform.position = new Vector3(
            x,
            transform.position.y,
            transform.position.z
        );

        chunk.SetActive(false);
        chunk.SetActive(true);
    }

    public override void HandleDespawn(GameObject obj)
    {
        // bool back = obj.GetComponent<ViewportDespawnController>().despawnBack;

        // Debug.Log(back);

        // if(!back) return;

        Debug.Log("Spawner Handle");

        base.HandleDespawn(obj);

        SpawnRight();

        // if(back) SpawnRight();
        // else     SpawnLeft();
    }
}