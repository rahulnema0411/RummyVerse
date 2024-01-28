using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlayPlayerHurtSound();
        collision.GetComponent<Player>().Hurt();
    }
}
