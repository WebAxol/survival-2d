using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] float parallaxFactor;
    public Transform tracked;
    private Vector3  lastPosition;
    void Start(){
        lastPosition = tracked.position;
    }

    // Update is called once per frame
    void Update(){
        Vector3 delta = tracked.position - lastPosition;

        if(delta.magnitude < 0.01) return;

        gameObject.transform.position += new Vector3(delta.x * parallaxFactor, 0f, 0f);

        lastPosition = tracked.position;
    }
}
