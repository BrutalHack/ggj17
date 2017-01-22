using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Background : MonoBehaviour
{
    public MovePlayer Player;
    public GameObject StartPrefab;
    public float StartMultiplier = -0.1f;
    public GameObject[] PartPrefabs;
    public Sprite[] BackgroundSprites;
    private Random _random = new Random();
    private List<GameObject> _existingParts = new List<GameObject>();
    private int _id;
    private string _idPattern = "00000";
    private string _name = "part-";
    [SerializeField]
    private float _partUpdatePositionX;

    // Use this for initialization
    void Start()
    {
        CreateStartPart();
        AppendRandomPart();
        AppendRandomPart();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetPlayerPositionX() >= _partUpdatePositionX)
        {
            DestroyOldestPart();
            AppendRandomPart();
            Player.IncreaseSpeed();
        }
    }

    private float GetPlayerPositionX()
    {
        if (Player != null)
        {
            return Player.transform.position.x;
        }
        return 0f;
    }

    private void CreateStartPart()
    {
        GameObject part = Instantiate(StartPrefab, transform);
        SetBackground(part);
        part.name = GenerateNextName();
        Vector3 newPosition = part.transform.position;
        newPosition.x += part.GetComponent<Renderer>().bounds.size.x * StartMultiplier;
        part.transform.position = newPosition;
        _existingParts.Add(part);
    }

    private void AppendRandomPart()
    {
        ChangeUpdatePositionToEndOfLastPart();
        GameObject lastPart = _existingParts.Last();
        GameObject newPart = CreateRandomPart();
        Vector3 newPosition = lastPart.transform.position;
        newPosition.x += lastPart.GetComponent<Renderer>().bounds.size.x;
        newPart.transform.position = newPosition;
    }

    private void ChangeUpdatePositionToEndOfLastPart()
    {
        GameObject lastPart = _existingParts.Last();
        float center = lastPart.transform.position.x;
        _partUpdatePositionX = center + lastPart.GetComponent<Renderer>().bounds.size.x / 2;
    }

    private GameObject CreateRandomPart()
    {
        int randomPosition = _random.Next(0, PartPrefabs.Length);
        GameObject part = Instantiate(PartPrefabs[randomPosition], transform);
        SetBackground(part);
        part.name = GenerateNextName();
        _existingParts.Add(part);
        return part;
    }

    private string GenerateNextName()
    {
        return _name + (++_id).ToString(_idPattern);
    }

    private void DestroyOldestPart()
    {
        int first = 0;
        GameObject oldestPart = _existingParts[first];
        _existingParts.RemoveAt(first);
        Destroy(oldestPart);
    }

    private void SetBackground(GameObject part)
    {
        Sprite background = BackgroundSprites[(_id) % BackgroundSprites.Length];
        part.GetComponent<SpriteRenderer>().sprite = background;
    }
}