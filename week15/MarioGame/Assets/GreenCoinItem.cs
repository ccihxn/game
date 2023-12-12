using UnityEngine;
public class GreenCoinItem : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Mario")
        {
            GameObject.Find("GameManager").SendMessage("GreenCoinStart");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
}