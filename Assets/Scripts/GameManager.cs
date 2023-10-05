using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }

    public int score = 0;
    public int lives = 3;
    public int level = 1;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start() {

        NewGame();
    }

    private void NewGame() {
        this.score = 0;
        this.lives = 3;

        LoadLevel(1);
    }

    private void LoadLevel(int level) {
        this.level = level;
        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode) {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
    }

    private void ResetLevel() {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver() {
        // SceneManager.LoadScene("GameOver");
        NewGame();
    }
    public void Miss() {
        this.lives--;

        if (this.lives > 0) {
            ResetLevel();
        }
        else {
            GameOver();
        }
    }
/*    private void TargetMassExceeded()
    {
        BlackHoles blackhole;
*//*        int targetMass = Random.Range(5, 100);
*//*
        if (blackhole.currentMass > targetMass)
        {
            GameOver();
        }
    }*/
}
