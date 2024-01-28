using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().Hurt();
    }
}
