using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    public bool IsOnGround { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Ground))
            IsOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Ground))
            IsOnGround = false;
    }
}
