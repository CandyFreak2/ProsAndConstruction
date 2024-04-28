using UnityEngine;

public class GameObjectToggle : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject sprite;

    public PlayerTools.Tools toolConditions;

    void Awake()
    {
        sprite.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && HasRequestedTool())
        {
            sprite.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public bool HasRequestedTool()
    {
        return toolConditions switch
        {
            PlayerTools.Tools.WRENCH => playerManager.HasWrench(),
            PlayerTools.Tools.WELDING_TOOL => playerManager.HasWelderMask(),
            PlayerTools.Tools.BOTH => playerManager.HasWrench() && playerManager.HasWelderMask(),
            PlayerTools.Tools.NONE => true,
            _ => false,
        };
    }
}
