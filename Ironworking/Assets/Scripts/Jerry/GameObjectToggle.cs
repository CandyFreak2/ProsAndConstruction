using UnityEngine;

public class GameObjectToggle : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject sprite;

    public PlayerTools.Tools toolConditions;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && HasRequestedTool())
        {
            sprite.SetActive(!sprite.activeSelf);
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
