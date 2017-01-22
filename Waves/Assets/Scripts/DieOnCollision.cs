using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnCollision : MonoBehaviour
{
    private int _layerIndex;
    private MovePlayer _movePlayer;
    private bool _canRestart;
    public GameObject DiesPopup;
    public float WaitTime = 0.5f;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Die()
    {
        _movePlayer.Die();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(WaitTime);
        _canRestart = true;
        DiesPopup.SetActive(true);
    }
}