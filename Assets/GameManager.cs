using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startText;

    private bool gameState;

    [SerializeField] private BallScript ball;

    private static int touchCounter = 0;

    private int playerScore = 0;
    private int enemyScore = 0;

    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text enemyScoreText;


    public bool GameState
    {
        get => gameState;

        set
        {
            gameState = value;
            if(value == true)
            {
                ball.AddInitialForce();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        GameState = false;
        startText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && touchCounter == 0)
        {
            startText.SetActive(false);
            GameState = true;
            touchCounter++;
        }
    }

    public void PlayerScores()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        StartCoroutine(ball.ResetPosition());
    }

    public void ComputerScores()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
        StartCoroutine(ball.ResetPosition());
    }


    

}
