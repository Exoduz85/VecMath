using Balls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
	public class GameManager : MonoBehaviour
	{
        public static GameManager Instance { get; private set; }
    
        [Header("UI")]
        public TextMeshProUGUI player1ScoreText;
        public TextMeshProUGUI player2ScoreText;
        public TextMeshProUGUI winnerText;
        public GameObject gameOverPanel;
        
        [Header("Game Settings")]
        public int scoreToWin = 5;

        int player1Score;
        int player2Score;
        bool gameOver;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            UpdateScoreUI();
            gameOverPanel.SetActive(false);
        }
        
        void Update()
        {
            if (gameOver && Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
        
        public void ScorePoint(int player)
        {
            if (gameOver) return;
            
            if (player == 1)
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }
            
            UpdateScoreUI();
            
            if (player1Score >= scoreToWin)
            {
                EndGame(1);
            }
            else if (player2Score >= scoreToWin)
            {
                EndGame(2);
            }
        }
        
        void UpdateScoreUI()
        {
            player1ScoreText.text = player1Score.ToString();
            player2ScoreText.text = player2Score.ToString();
        }
        
        void EndGame(int winner)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            winnerText.text = $"Player {winner} Wins!\nPress R to Restart";
            
            var ball = FindFirstObjectByType<Ball>();
            if (ball != null)
            {
                ball.enabled = false;
            }
        }
        
        void RestartGame()
        {
            player1Score = 0;
            player2Score = 0;
            gameOver = false;
            
            UpdateScoreUI();
            gameOverPanel.SetActive(false);
            
            var ball = FindFirstObjectByType<Ball>();
            if (ball != null)
            {
                ball.enabled = true;
                ball.ResetBall();
            }
        }
	}
}