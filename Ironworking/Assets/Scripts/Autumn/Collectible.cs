using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float visibility = 0.5f;
    [SerializeField] int id;
    SpriteRenderer mSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        //mSpriteRenderer.color = new Color(139f/255, 150f/255, 255f/255, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            mSpriteRenderer.color = new Color(mSpriteRenderer.color.r, mSpriteRenderer.color.g, mSpriteRenderer.color.b, visibility);
            GameEvents.instance.ObjectPickupEvent(id);
        }
    }

}
