using UnityEngine;
using UnityEngine.UI;
public class GameController:MonoBehaviour
{
    private int scoreLeft = 0;
    private int scoreRight = 0;
    public int maxScore = 3;
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public Text gameOverText;
    private bool started = false;
    public GameObject ball;
    private BallController ballController;
    private Vector3 startingPosition;
    public Starter starter;
    void Start()
    {
        this.gameOverText.gameObject.SetActive(false);
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }

    void Update()
    {
        if (started)
            return;

        if (Input.GetKey(KeyCode.Space))
        { started = true;
            this.gameOverText.gameObject.SetActive(false);
            this.starter.StartCountdown();
        }
    }

    public void ScoreGoalLeft()
    {
        scoreLeft++;
        UpdateUI();
        if (scoreLeft >= maxScore)
        {
            EndGame("Left");
            return;
        }
        ResetBall();
        Debug.Log("Left Team Scored! Score: " + scoreLeft + " - " + scoreRight);
    }

    public void StartGame()
    {
        this.ballController.Go();
    }
    public void ScoreGoalRight()
    {
        scoreRight++;
        UpdateUI();
        if (scoreRight >= maxScore)
        {
            EndGame("Right");
            return;
        }
        ResetBall();
        Debug.Log("Right Team Scored! Score: " + scoreLeft + " - " + scoreRight);
    }
    private void EndGame(string winner)
    {
        Debug.Log(winner + " team wins!");
        started = false;
        ballController.Stop();
        gameOverText.gameObject.SetActive(true);
    }

    private void UpdateUI()
    {
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();
    }
    public void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }
}
