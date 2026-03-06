using UnityEngine;

/// <summary>
/// Follows a given transform based on position deltas multiplied by a given
/// parallax factor.
/// </summary>
public class ParallaxController : MonoBehaviour
{
    [SerializeField] float parallaxFactor;
    public Transform tracked;
    public bool fixedX = false;
    public bool fixedY = false;

    public Vector3 startPosition;
    public Vector3 trackedStart;

    void Start(){
        OnEnable();
    }

    void OnEnable(){

        if(tracked == null) tracked = Camera.main.transform;

        ResetReference();
    }

    void ResetReference(){
        startPosition = transform.position;
        trackedStart = tracked.position;
    }

    // Update is called once per frame
    void Update(){

        Vector3 delta = tracked.position - trackedStart;

        Debug.Log(delta);

        float deltaX = fixedX ? 0f : delta.x * parallaxFactor;
        float deltaY = fixedY ? 0f : delta.y * parallaxFactor;

        transform.position = new Vector3(
            startPosition.x + deltaX,
            startPosition.y + deltaY,
            startPosition.z
        );
    }
}