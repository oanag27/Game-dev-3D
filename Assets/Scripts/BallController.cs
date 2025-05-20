using Unity.VisualScripting;
using UnityEngine;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

public class BallController:MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    public float minDirection =0.5f;
    private bool stopped = false;
    void Start()
    {
        // Initialize the ball controller
        this.rb = GetComponent<Rigidbody>();
       // this.direction = new Vector3(0.5f, 0, 0.5f);
      // ChangeDirection();
    }

    void Update()
    {
        //transform.position += this.direction * this.speed * Time.deltaTime;
    }
    void FixedUpdate()
    {
        if(this.stopped)
            return;
        this.rb.MovePosition(this.rb.position + this.direction * this.speed * Time.fixedDeltaTime);
    }

    public void Stop()
    {
        this.stopped = true;
    }

    public void Go()
    {
        ChangeDirection();
        this.stopped = false;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the ball hits a racket
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) *Mathf.Max(Mathf.Abs(newDirection.x), minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), minDirection);
            direction = newDirection;
        }
        if (other.CompareTag("Wall"))
        {
            direction.z = -this.direction.z;
        }
    }

    void ChangeDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        direction = new Vector3(0.5f*signX, 0, 0.5f*signZ);
    }
}
