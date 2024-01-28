using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.instance.KeyCollected();
        AudioManager.instance.PlayKeyCollectionSound();
        Destroy(gameObject);
    }
}
