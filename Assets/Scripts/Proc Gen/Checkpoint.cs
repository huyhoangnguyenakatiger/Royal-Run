using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameManager gameManager;
    [SerializeField] float checkpointTimeExtension = 5f;
    const string playerString = "Player";
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerString))
        {
            gameManager.IncreaseTime(checkpointTimeExtension);
        }

    }
}
