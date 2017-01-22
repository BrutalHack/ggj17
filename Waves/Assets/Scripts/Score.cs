using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject Player;
    public Text ScoreText;
    private float _startPositionX;

	// Use this for initialization
	void Start ()
	{
	    _startPositionX = CurrentPositionX();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = GetScoreAsString();
	}

    private float CurrentPositionX()
    {
        return Player.transform.position.x;
    }

    private String GetScoreAsString()
    {
        float score = CurrentPositionX() - _startPositionX;
        if (score < 1)
        {
            return "0";
        }
        return score.ToString("n2");
    }
}
