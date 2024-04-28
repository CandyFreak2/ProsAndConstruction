using UnityEngine;

public class RespawnObjects : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    void Start()
    {
        if (TryGetComponent(out boxCollider))
        {
            boxCollider.isTrigger = true;
        }
        else
        {
            Debug.LogError("No BoxCollider2D found on the GameObject.");
        }
    }
}
