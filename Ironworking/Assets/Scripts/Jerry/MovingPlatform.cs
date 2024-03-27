using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementSpeed;     
    public int startingPoint;       
    public Transform[] rangePoints;
    public bool isPlatformAllowed;

    private int currentPointIndex; 

    void Start()
    {
        transform.position = rangePoints[startingPoint].position;
        currentPointIndex = startingPoint; 
    }

    void Update()
    {
        if (isPlatformAllowed)
        {
            if (HasReachedTargetPoint())
            {
                MoveToNextPoint();
            }

            MoveTowardsTargetPoint();
        }
    }

    bool HasReachedTargetPoint()
    {
        float distanceToTarget = Vector2.Distance(transform.position, rangePoints[currentPointIndex].position);
        return distanceToTarget < 0.02f;
    }

    void MoveToNextPoint()
    {
        currentPointIndex++;
        if (currentPointIndex >= rangePoints.Length)
        {
            currentPointIndex = 0;
        }
    }

    void MoveTowardsTargetPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, rangePoints[currentPointIndex].position, movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    public void IsPlatformAllowedToMove() {
        if (!isPlatformAllowed) {
            isPlatformAllowed = true;
            Debug.Log("Platform Can Move");
            // for future usage, anims go below
        } else if (isActiveAndEnabled) { 
            isPlatformAllowed = false;
            Debug.Log("Platform Cannot Move");
        }
    }
}
