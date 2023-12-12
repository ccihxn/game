using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    GameObject mario;
    // Start is called before the first frame update
    void Start()
    {
        mario = GameObject.Find("Mario");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        for (int i = 0; i < coins.Length; i++)
        {
            Debug.Log(coins[i].name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0,
        mario.transform.position.y + 3,
        mario.transform.position.z - 14);
    }
}