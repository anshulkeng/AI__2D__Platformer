using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // who to follow (the player)
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 targetPos = target.position + offset;

        // Keep original Z if you like
        targetPos.z = offset.z;

        // Smooth follow
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}
