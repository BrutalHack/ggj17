using UnityEngine;

public class CompleteCameraController : MonoBehaviour
{
    public GameObject Player;

    void LateUpdate()
    {
        if (Player != null)
        {
            var transformPosition = transform.position;
            transformPosition.x = Player.transform.position.x;
            transform.position = transformPosition;
        }
    }
}