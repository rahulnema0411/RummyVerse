using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -10f);

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, 0, offset.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
