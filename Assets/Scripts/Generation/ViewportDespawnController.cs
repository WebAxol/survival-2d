using UnityEngine;


/// <summary>
/// Handles despawn when the object is out of screen
/// </summary>
public class ViewportDespawnController : Spawnable{

    public bool despawnBack = false;
    public float graceMarginLeft = 0.2f;
    public float graceMarginRight = 0.2f;

    private Renderer _renderer;

    void Start(){
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }


    /// <summary>
    /// Evaluates if the object is within screen limits: if not, it despawns.
    /// Attribute "daspawnBack" is true if the object is out of the left limit, and false otherwise.
    /// </summary>
    void Update(){        

        float halfWidth = _renderer.bounds.extents.x;

        Vector3 posL = transform.position - new Vector3(halfWidth,0f,0f);
        Vector3 posR = transform.position + new Vector3(halfWidth,0f,0f);

        if(Camera.main.WorldToViewportPoint(posR).x < 0 - graceMarginRight){
            despawnBack = true;
            Despawn();   
            return;
        }
        if(Camera.main.WorldToViewportPoint(posL).x > 1 + graceMarginLeft){   
            despawnBack = false;
            Despawn();
        }
    }
}
