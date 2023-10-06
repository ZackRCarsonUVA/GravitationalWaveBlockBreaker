using UnityEngine;

public class BlackHoles : MonoBehaviour
{
    private int slow = 0;

    public float currentMass = 5.0f;
    public float currentRadius = 2f;
    //public static float G = 6.67f * Mathf.Pow(10, -11);
    public static float G = 6.67f;
    public static GameObject ball;

    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 5f; // Adjust the speed as needed

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddGravity(this.rigidbody, Ball.rigid);
        AddGravity(Ball.rigid, this.rigidbody);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball referenceToBallHit = collision.gameObject.GetComponent<Ball>();

        if (referenceToBallHit != null) // Check if collided with the ball
        {
            if (referenceToBallHit.ballMass == currentMass)
            {
                referenceToBallHit.ballMass = currentMass * 2;
                referenceToBallHit.ballRadius = currentRadius * 2;

                Vector3 lastScale = referenceToBallHit.transform.localScale;
                lastScale = lastScale * 2f;
                referenceToBallHit.transform.localScale = lastScale;
            }
            if (referenceToBallHit.ballMass != currentMass && currentMass > referenceToBallHit.ballMass)
            {
                float massScale = (currentMass / referenceToBallHit.ballMass);
                float radiusScale = (currentMass / referenceToBallHit.ballRadius);

                referenceToBallHit.ballMass = referenceToBallHit.ballMass * massScale;
                referenceToBallHit.ballRadius = referenceToBallHit.ballRadius * radiusScale;

                Vector3 lastScale = referenceToBallHit.transform.localScale;
                lastScale = lastScale * radiusScale;
                referenceToBallHit.transform.localScale = lastScale;
            }
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        AddGravity(this.rigidbody, Ball.rigid);
        AddGravity(Ball.rigid, this.rigidbody);
    }

    public static void AddGravity(Rigidbody2D attractor, Rigidbody2D pulled)
    {
        float product = attractor.mass * pulled.mass * BlackHoles.G;
        Vector2 sub = attractor.position - pulled.position;
        float dis = sub.magnitude;

        float FM = G * (product / Mathf.Pow(dis, 2));

        Vector2 dir = sub.normalized;

        Vector2 vec = dir * FM;

        pulled.AddForce(vec * 0.5f);
    }
}