using UnityEngine;

public class Spawnable : MonoBehaviour
{
    protected Spawner spawner;
    protected virtual void OnSpawn(){}
    public void SetSpawner(Spawner spawner){
        this.spawner = spawner;
    }

    public virtual void Despawn()
    {
        if (spawner != null){
            spawner.HandleDespawn(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}