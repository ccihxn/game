using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour
{
    // 이벤트에 할당할 함수
    public void OnClick()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene("SampleScene");
        GameObject.Find("GameManager").SendMessage("RestartGame");
    }
}