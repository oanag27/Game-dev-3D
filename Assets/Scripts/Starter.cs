using UnityEngine;

public class Starter:MonoBehaviour
{
    private GameController gameController;
    private Animator animator;

    void Start()
    {
        this.gameController = FindObjectOfType<GameController>();
        this.animator = GetComponent<Animator>();
    }
    public void StartGame()
    {
        this.gameController.StartGame();
        //this.animator.SetTrigger("StartGame");
    }

    public void StartCountdown()
    {
        this.animator.SetTrigger("StartCountdown");
    }
}
