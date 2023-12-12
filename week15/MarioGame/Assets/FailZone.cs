using UnityEngine;
public class FailZone : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "Mario")
        {
            //GameObject.Find("GameManager").SendMessage("RestartGame");
            GameObject gm = GameObject.Find("GameManager");
            GameManager gmComponent = gm.GetComponent<GameManager>();
            //GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
            gmComponent.GameOver();
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