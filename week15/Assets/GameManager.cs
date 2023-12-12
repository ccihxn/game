using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public int coinCount = 0;
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트

    void Start()
    {
        LoadScore(); // 게임이 시작할 때 저장된 점수를 로드
        UpdateScoreUI(); // 점수 UI 업데이트

        // 점수 텍스트 UI의 위치를 우측 상단으로 설정합니다.
        scoreText.rectTransform.anchorMin = new Vector2(1, 1);
        scoreText.rectTransform.anchorMax = new Vector2(1, 1);
        scoreText.rectTransform.pivot = new Vector2(1, 1); // 피벗을 우측 상단으로 설정
        scoreText.rectTransform.anchoredPosition = new Vector2(-10, -10); // 오른쪽과 위쪽으로부터 10의 간격을 줍니다.
    }

    public void GetCoin()
{
    coinCount++;
    score++; // 코인을 획득할 때마다 점수를 증가
    UpdateScoreUI(); // UI 텍스트 업데이트
    Debug.Log("GetCoin called. Coin: " + coinCount + ", Score: " + score); // 메서드 호출 로그 출력
}

    // 점수 UI를 업데이트하는 메서드
    public void UpdateScoreUI()
    {
        coinText.text = "Coin: " + coinCount.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save(); // 데이터를 저장하기 위해 호출
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI(); // 점수 UI 업데이트
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            DestroyObstacles();
            Destroy(gameObject);
        }
    }
    void RedCoinStart()
    {
        DestroyObstacles();
    }
    void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }
    // ... 기타 메서드와 로직 ...
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 현재 씬을 다시 로드
    }

}
