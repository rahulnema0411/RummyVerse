using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlayPlayerHurtSound();
        collision.GetComponent<Player>().Hurt();
    }
}
