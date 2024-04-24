using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementSpeed;
    public int startingPoint;
    public Transform[] rangePoints;
    public bool isPlatformAllowed;
    public PlatformCondition.PlatformConditions platformCondition;
    public int roomToProceed, npcInteraction;

    private int currentPointIndex;
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

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
        else
        {
            if (roomToProceed == playerManager.GetCurrentRoomSelection() || playerManager.GetNPCInteractionCount() == npcInteraction)
            {
                switch (platformCondition)
                {
                    case PlatformCondition.PlatformConditions.WRENCH:
                        isPlatformAllowed = playerManager.HasWrench();
                        break;
                    case PlatformCondition.PlatformConditions.WELDING_TOOL:
                        isPlatformAllowed = playerManager.HasWelderMask();
                        break;
                    case PlatformCondition.PlatformConditions.BOTH:
                        isPlatformAllowed = playerManager.HasWrench() && playerManager.HasWelderMask();
                        break;
                    case PlatformCondition.PlatformConditions.NONE:
                        break;
                    default:
                        isPlatformAllowed = false;
                        break;
                }
            }
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

    public void IsPlatformAllowedToMove()
    {
        if (!isPlatformAllowed)
        {
            isPlatformAllowed = true;
            Debug.Log("Platform Can Move");
        }
        else if (isActiveAndEnabled)
        {
            isPlatformAllowed = false;
            Debug.Log("Platform Cannot Move");
        }
    }
}
