using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementSpeed;
    public int startingPoint;
    public Transform[] rangePoints;
    public bool isPlatformAllowed;

    private int currentPointIndex;
    private PlayerManager playerManager;

    [Header("Conditionals to Trigger")]
    public PlayerTools.Tools requiredTools;
    public int npcCountTrigger;

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
            if (playerManager.GetNPCInteractionCount() == npcCountTrigger)
            {
                switch (requiredTools)
                {
                    case PlayerTools.Tools.WRENCH:
                        isPlatformAllowed = playerManager.HasWrench();
                        break;
                    case PlayerTools.Tools.WELDING_TOOL:
                        isPlatformAllowed = playerManager.HasWelderMask();
                        break;
                    case PlayerTools.Tools.BOTH:
                        isPlatformAllowed = playerManager.HasWrench() && playerManager.HasWelderMask();
                        break;
                    case PlayerTools.Tools.NONE:
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
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("Platform Can Move");
        }
        else if (isActiveAndEnabled)
        {
            isPlatformAllowed = false;
            this.GetComponent<AudioSource>().Stop();
            //Debug.Log("Platform Cannot Move");
        }
    }

    public PlayerTools.Tools GetRequiredTools()
    {
        return requiredTools;
    }
}
