using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip gameoverSound;  // 시작 시 재생할 짧은 음악
    public AudioClip backgroundMusic;  // 배경음악
    public AudioSource audioSource;  // Audio Source 컴포넌트

    void Start()
    {
        // 시작 시 짧은 음악을 재생합니다.
        if (gameoverSound != null)
        {
            audioSource.clip = gameoverSound;
            audioSource.Play();
            
            // 짧은 음악이 종료되면 배경음악으로 전환하는 코루틴을 시작합니다.
            StartCoroutine(PlayBackgroundMusicAfterIntro());
        }
    }

    // 짧은 음악 종료 후 배경음악을 재생하는 코루틴
    private System.Collections.IEnumerator PlayBackgroundMusicAfterIntro()
    {
        // 짧은 음악의 길이를 기다립니다.
        yield return new WaitForSeconds(gameoverSound.length);

        // 배경음악을 재생합니다.
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;  // 반복 재생 설정
            audioSource.Play();
        }
    }
}
