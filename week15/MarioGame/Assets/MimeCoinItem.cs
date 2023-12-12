using UnityEngine;

public class MimeCoinItem : MonoBehaviour
{
    public Material mimeMarioMaterial; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MimeCoin") {
            GameObject marioObject = GameObject.Find("Mario");

            if (marioObject != null)
            {
                Renderer marioRenderer = marioObject.GetComponent<Renderer>();

                if (marioRenderer != null && mimeMarioMaterial != null)
                {
                    marioRenderer.material = mimeMarioMaterial;
                }
            }
        }
    }
}
