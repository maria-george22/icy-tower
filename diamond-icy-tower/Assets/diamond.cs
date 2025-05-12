using UnityEngine;
using UnityEngine.SceneManagement;

public class diamond : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}