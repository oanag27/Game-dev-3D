using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed = 10f;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    private Rigidbody rb;
    private bool isPlayer = true;
    private Transform ballTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    void Update()
    {
        if(isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByAI();
        }
    }

    void MoveByPlayer()
    {
        bool pressedUp = Input.GetKey(up);
        bool pressedDown = Input.GetKey(down);

        if (pressedUp)
        {
            rb.linearVelocity = Vector3.forward * speed;
        }
        else if (pressedDown)
        {
            rb.linearVelocity = Vector3.back * speed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
    void MoveByAI()
    {
        if(ballTransform.position.z > transform.position.z)
        {
            rb.linearVelocity = Vector3.forward * speed;
        }
        else if (ballTransform.position.z < transform.position.z)
        {
            rb.linearVelocity = Vector3.back * speed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}