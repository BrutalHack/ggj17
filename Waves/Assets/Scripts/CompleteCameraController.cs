using UnityEngine;

public class CompleteCameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start ()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
    }
}