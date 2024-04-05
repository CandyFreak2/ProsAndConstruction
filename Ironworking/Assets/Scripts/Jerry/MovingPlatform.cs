using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementSpeed;
    public int startingPoint;
    public Transform[] rangePoints;
    public bool isPlatformAllowed, canResetLocation;
    public bool mustPlayerBeOnPlatform, isAllowedToContinue;

    private int currentPointIndex;
    private const float resetTimer = 0f, resetDelay = 4f;
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
                if (!mustPlayerBeOnPlatform || IsPlayerOnPlatform())
                {
                    MoveToNextPoint();
                    if ((currentPointIndex == (rangePoints.Length - 1)) && transform.position.y == rangePoints[currentPointIndex].position.y)
                    {
                        isAllowedToContinue = false;
                        canResetLocation = true;
                        if (canResetLocation && Time.time > resetTimer + resetDelay)
                        {
                            if (IsPlayerOnPlatform() && !isAllowedToContinue)
                            {
                                MoveToSpecificPoint(startingPoint);
                            }
                        }
                        return;
                    }
                    isAllowedToContinue = false;
                }
            }
            MoveTowardsTargetPoint();
        }
    }

    bool HasReachedTargetPoint()
    {
        float distanceToTarget = Vector2.Distance(transform.position, rangePoints[currentPointIndex].position);
        return distanceToTarget < 0.02f;
    }

    bool IsPlayerOnPlatform()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }


    void MoveToNextPoint()
    {
        if (!mustPlayerBeOnPlatform)
        {
            currentPointIndex++;
            if (currentPointIndex >= rangePoints.Length)
            {
                currentPointIndex = 0;
            }
        }
        else if (isAllowedToContinue)
        {
            currentPointIndex++;
            if (currentPointIndex >= rangePoints.Length)
            {
                currentPointIndex = rangePoints.Length - 1;
            }
        }
    }

    void MoveToSpecificPoint(int index)
    {
        isAllowedToContinue = true;
        currentPointIndex = index;
        transform.position = Vector2.MoveTowards(transform.position, rangePoints[currentPointIndex].position, movementSpeed * Time.deltaTime);
    }

    void MoveTowardsTargetPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, rangePoints[currentPointIndex].position, movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            isAllowedToContinue = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            if (canResetLocation) { 
                isAllowedToContinue = false;
            }
        }
    }

    public void IsPlatformAllowedToMove()
    {
        if (!isPlatformAllowed)
        {
            isPlatformAllowed = true;
            Debug.Log("Platform Can Move");
        }
        else
        {
            isPlatformAllowed = false;
            Debug.Log("Platform Cannot Move");
        }
    }
}
