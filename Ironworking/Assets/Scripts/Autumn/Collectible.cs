using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float imageAlpha = 0.5f;
    [SerializeField] int collectibleID;
    public PlayerManager playerManager;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //mSpriteRenderer.color = new Color(139f/255, 150f/255, 255f/255, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, imageAlpha);
            GameEvents.instance.ObjectPickupEvent(collectibleID);
            
            switch (collectibleID)
            {
                case 0:
                    playerManager.SetHasWrench(true);
                    break;
                case 1:
                    playerManager.SetHasWeldingMask(true);
                    break;
            }

        }
    }

}
