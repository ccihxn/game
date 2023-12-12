using UnityEngine;
public class CoinTrigger : MonoBehaviour
{
    public AudioClip coinSound;
    public GameManager gameManager;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Mario")
        {       
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            GameObject.Find("GameManager").GetComponent<GameManager>().GetCoin();
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