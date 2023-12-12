using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour
{
    // 이벤트에 할당할 함수
    public void OnClick()
    {
        Debug.Log("Button Clicked");
        Application.Quit();
    }
}