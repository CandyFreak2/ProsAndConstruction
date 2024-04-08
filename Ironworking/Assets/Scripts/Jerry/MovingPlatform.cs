using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementSpeed;
    public int startingPoint;
    public Transform[] rangePoints;
    public bool isPlatformAllowed;
    public bool mustPlayerBeOnPlatform, isAllowedToContinue;

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
                if (!mustPlayerBeOnPlatform || IsPlayerOnPlatform())
                {
                    MoveToNextPoint();

                    if (currentPointIndex == rangePoints.Length - 1 && transform.position.y == rangePoints[currentPointIndex].position.y)
                    {
                        if (IsPlayerOnPlatform())
                        {
                            currentPointIndex = 0;
                            isPlatformAllowed = !isPlatformAllowed;
                            isAllowedToContinue = true;
                            return;
                        }
                    }
                }
            }
            if (isAllowedToContinue)
            {
                MoveTowardsTargetPoint();
                return;
            }
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
            isAllowedToContinue = false;
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