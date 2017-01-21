using UnityEngine;

public class CompleteCameraController : MonoBehaviour
{
    public GameObject Player;

    void LateUpdate()
    {
        var transformPosition = transform.position;
        transformPosition.x = Player.transform.position.x;
        transform.position = transformPosition;
    }
}