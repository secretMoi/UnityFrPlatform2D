using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    [FormerlySerializedAs("positionOffset")] public Vector3 playerPositionOffset;
    
    private Vector3 velocity;
    
    void Update()
    {
        // déplace la caméra à la position du joueur
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + playerPositionOffset, ref velocity, timeOffset);
    }
}
