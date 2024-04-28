using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    [SerializeField] float minSlide = -10f;
    [SerializeField] float maxSlide = 10f;
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld;
    private bool isBeingClimbed = false;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = this.transform.localPosition.x;
        startPosY = this.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {

            getMousePos();
            float newPosX = mousePos.x - startPosX;
            if (newPosX < maxSlide && newPosX > minSlide) 
            {
                this.gameObject.transform.localPosition = new Vector3(newPosX, startPosY, 0);
            }

        
        }
    }

    void OnMouseDown() 
    {
        
        if (Input.GetMouseButtonDown(0) && !isBeingClimbed)
        {
            getMousePos();
            startPosX = mousePos.x - this.transform.localPosition.x;
            isBeingHeld = true;
        }
    
    }

    void OnMouseUp()
    {
        isBeingHeld = false;
    }

    private void getMousePos()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBeingClimbed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBeingClimbed = false;
        }
    }
}
//https://www.youtube.com/watch?v=eUWmiV4jRgU