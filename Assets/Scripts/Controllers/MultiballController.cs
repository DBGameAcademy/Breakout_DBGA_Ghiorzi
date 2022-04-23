using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiballController : Singleton<MultiballController>
{
    public int BallCount { get; private set; }
    public List<Ball> Balls { get => _balls; }

    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private Vector3 ballSpawnPoint;

    private List<Ball> _balls = new List<Ball>();

    public void AddBall()
    {
        GameObject ballObj = Instantiate(ballPrefab, ballSpawnPoint, Quaternion.identity);
        Ball ball = ballObj.GetComponent<Ball>();

        // Same velocity of the other balls (yes? no?)
        ball.Velocity = _balls[0].Velocity;

        _balls.Add(ball);
        BallCount++;
    }

    public void RemoveBall(Ball ball)
    {
        if (BallCount == 1)
            return;
        if (!_balls.Contains(ball))
            return;

        _balls.Remove(ball);
        BallCount--;
    }

    public void ResetGameBall()
    {
        _balls[0].BallReset();
        Ball firstBall = _balls[0];

        if(BallCount >= 2)
        {
            for(int i=1; i<_balls.Count; ++i)
            {
                Destroy(_balls[i].gameObject);
            }
            _balls = new List<Ball>();
            _balls.Add(firstBall);
        }
    }

    public void ResetAllBallVelocity()
    {
        foreach (Ball ball in _balls)
        {
            ball.ResetVelocity();
        }
    }

    private void Start()
    {
        BallCount = 0;

        Ball[] tempBalls = FindObjectsOfType<Ball>();
        foreach (Ball ball in tempBalls)
        {
            _balls.Add(ball);
        }

        BallCount = _balls.Count;
    }

    private void Update()
    {
        Debug.Log("Ball Count "+BallCount);
    }

}
