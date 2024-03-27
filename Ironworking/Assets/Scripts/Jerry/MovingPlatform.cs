using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementSpeed;     
    public int startingPoint;       
    public Transform[] rangePoints; 

    private int currentPointIndex; 

    void Start()
    {
       
        transform.position = rangePoints[startingPoint].position;
        currentPointIndex = startingPoint; 
    }

    void Update()
    {
        if (HasReachedTargetPoint())
        {
            MoveToNextPoint();
        }

        MoveTowardsTargetPoint();
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
}
