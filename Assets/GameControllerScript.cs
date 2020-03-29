using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public UnityEngine.UI.Text scoreText;

    int score = 0;

    public static GameControllerScript instance;
    public void incrementScore(int addition)
    {
        score += addition;
        scoreText.text = "Score: " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
