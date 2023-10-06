using UnityEngine;

public class Ball : MonoBehaviour {
    public new Rigidbody2D rigidbody  {get; private set; }
    public float speed = 500f;

    public float ballMass = 5.0f;
    public float ballRadius = 1f;

    public static Rigidbody2D rigid;

    public void Awake() {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        ResetBall();
        rigid = this.rigidbody;
    }

    public void ResetBall() {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);

    }
    
    private void SetRandomTrajectory() {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f; //always down

        this.rigidbody.AddForce(force.normalized * this.speed);
    }
}
