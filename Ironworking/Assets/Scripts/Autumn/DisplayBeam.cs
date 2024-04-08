using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBeam : MonoBehaviour
{
    private GameObject child;
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        child = this.transform.GetChild(0).gameObject;
        child.SetActive(true);
        child = this.transform.GetChild(1).gameObject;
        child.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBeam(bool isSmall) 
    {
        child = this.transform.GetChild(0).gameObject;
        child.SetActive(false);
        child = this.transform.GetChild(1).gameObject;
        child.SetActive(true);

        if (isSmall && playerManager != null)
        {
            playerManager.RemoveSmallBeam();
        }
        else
        {
            playerManager.RemoveLargeBeam();
        }
    }
}
