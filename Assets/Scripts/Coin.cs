using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.instance.CoinCollected();
        AudioManager.instance.PlayCoinCollectionSound();
        Destroy(gameObject);
    }
}
