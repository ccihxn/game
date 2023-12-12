using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public int coinCount = 0;
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    public AudioClip gameOverSound;
    public AudioSource mainCameraAudio;

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
    void Update()
    {
        // R 키를 한 번 누를 때 디버그 메시지 출력 및 Restart 함수 호출
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R Key Pressed");
            RestartGame();
        }

        // Q 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q Key Pressed");
            GameOver();
        }

        // M 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M Key Pressed");
            mainCameraAudio.Stop();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P Key Pressed");
            mainCameraAudio.Play();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I Key Pressed");
            SceneManager.LoadScene("Intro");
        }
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
        if (collider.gameObject.name == "Mario")
        {
            DestroyObstacles();
            Destroy(gameObject);
        }
    }
    void RedCoinStart()
    {
        GameOver();
    }
    void GreenCoinStart()
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

    public void GameOver()
    {
        if (mainCameraAudio != null)
        {
            mainCameraAudio.Stop();
        }
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        // 게임 오버 화면을 띄우거나 다른 게임 오버 관련 로직을 수행할 수 있습니다.
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver");
        // RestartGame();
        // 여기에 게임 오버 화면을 띄우는 로직이나 다른 게임 오버 처리를 추가할 수 있습니다.
        // scoreText.text = "Final Score: " + score.ToString();
    }
    public void QuitGame()
    {
        // 어플리케이션을 종료합니다. (빌드된 빌드에서만 동작)
        Application.Quit();
    }

}
