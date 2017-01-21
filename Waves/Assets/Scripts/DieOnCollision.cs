using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    private int _layerIndex;
    private MovePlayer _movePlayer;

    void Awake()
    {
        _movePlayer = GetComponent<MovePlayer>();
        _layerIndex = LayerMask.NameToLayer("Obstacle");
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == _layerIndex)
        {
            Die();
        }
    }

    private void Die()
    {
        _movePlayer.Die();
        Debug.Log("Dead");
    }
}