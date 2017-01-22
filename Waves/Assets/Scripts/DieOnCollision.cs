using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnCollision : MonoBehaviour
{
    private int _layerIndex;
    private MovePlayer _movePlayer;
    private bool _canRestart;

    void Awake()
    {
        _movePlayer = GetComponent<MovePlayer>();
        _layerIndex = LayerMask.NameToLayer("Obstacle");
        _canRestart = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == _layerIndex)
        {
            Die();
        }
    }

    void Update()
    {
        if (_canRestart && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void Die()
    {
        _movePlayer.Die();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        _canRestart = true;
    }
}