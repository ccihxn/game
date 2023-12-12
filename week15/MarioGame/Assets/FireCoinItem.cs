using UnityEngine;

public class FireCoinItem : MonoBehaviour
{
    public Material fireMarioMaterial; // FireMario로 변경할 Material

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FireCoin") // 정의한 태그명인 "FireCoin"으로 수정
        {
            // Mario 객체를 찾습니다. 이 부분은 적절한 방법으로 Mario 객체를 찾아야 합니다.
            GameObject marioObject = GameObject.Find("Mario");

            if (marioObject != null)
            {
                // Mario 객체의 Renderer 컴포넌트를 가져옵니다.
                Renderer marioRenderer = marioObject.GetComponent<Renderer>();

                if (marioRenderer != null && fireMarioMaterial != null)
                {
                    // Mario 객체의 Material을 FireMario로 변경합니다.
                    marioRenderer.material = fireMarioMaterial;
                }
            }
        }
    }
}
