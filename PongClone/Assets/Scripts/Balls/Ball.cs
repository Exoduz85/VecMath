using Goals;
using Manager;
using NativeVector;
using Paddles;
using UnityEngine;
using Walls;

namespace Balls
{
	public class Ball : MonoBehaviour
	{
        [Header("Ball Settings")]
        public float initialSpeed = 5f;
        public float maxSpeed = 15f;
        public float speedIncreasePerHit = 0.5f;
        
        Vec2 velocity;
        float currentSpeed;
        
        void Start()
        {
            ResetBall();
        }
        
        void Update()
        {
            var currentPos = Vec2.FromUnity(transform.position);
            var scaledVelocity = VecHelper.Scale(velocity, Time.deltaTime);
            var newPos = VecHelper.Add(currentPos, scaledVelocity);
            
            transform.position = newPos.ToUnity();
        }
        
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Paddle>())
            {
                HandlePaddleCollision(collision);
            }
            else if (collision.gameObject.GetComponent<Wall>())
            {
                HandleWallCollision(collision);
            }
            else if (collision.gameObject.GetComponent<Goal>())
            {
                HandleGoalCollision(collision.gameObject.GetComponent<Goal>());
            }
        }
        
        void HandleWallCollision(Collider2D wall)
        {
            var wallComponent = wall.gameObject.GetComponent<Wall>();
            var normal = wallComponent.GetNormal();
            
            velocity = VecHelper.Reflect(velocity, normal);
        }
        
        void HandlePaddleCollision(Collider2D paddle)
        {
            var paddlePos = Vec2.FromUnity(paddle.transform.position);
            var ballPos = Vec2.FromUnity(transform.position);
            
            var paddleHeight = paddle.bounds.size.y;
            
            var difference = VecHelper.Subtract(ballPos, paddlePos);
            var relativeHitY = difference.y / (paddleHeight / 2f);
            relativeHitY = Mathf.Clamp(relativeHitY, -1f, 1f);
            
            var maxAngle = 60f * Mathf.Deg2Rad;
            var angle = relativeHitY * maxAngle;
            
            var directionX = (paddlePos.x < 0) ? 1f : -1f;
            
            var direction = new Vec2(
                Mathf.Cos(angle) * directionX,
                Mathf.Sin(angle)
            );
            
            direction = VecHelper.Normalize(direction);
            
            currentSpeed = Mathf.Min(currentSpeed + speedIncreasePerHit, maxSpeed);
            
            velocity = VecHelper.Scale(direction, currentSpeed);
        }
        
        void HandleGoalCollision(Goal goal)
        {
            GameManager.Instance.ScorePoint(goal.scoringPlayer);
            ResetBall();
        }
        
        public void ResetBall()
        {
            transform.position = Vector2.zero;
            
            currentSpeed = initialSpeed;
            
            var randomAngle = Random.Range(-30f, 30f) * Mathf.Deg2Rad;
            var directionX = Random.value < 0.5f ? -1f : 1f;
            
            var direction = new Vec2(
                Mathf.Cos(randomAngle) * directionX,
                Mathf.Sin(randomAngle)
            );
            
            direction = VecHelper.Normalize(direction);
            velocity = VecHelper.Scale(direction, currentSpeed);
        }
	}
}