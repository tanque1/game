using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    Direction direction;

    [SerializeField]
    int startDistance;

    [SerializeField]
    int stopDistance;

    [SerializeField]
    public float Speed;

    [SerializeField]
    bool moveTowardsStart = true;

    [SerializeField]
    bool shouldFlip = true;

    float start;

    float stop;

    bool isHorizontal = true;

    private void Start()
    {
        DetermineIfMoveDirectionIsHorizontal();
        SetStartAndStopPosition();
    }

    void FixedUpdate()
    {
        if (isHorizontal)
        {
            transform.position +=
                moveTowardsStart
                    ? new Vector3(-Speed * Time.fixedDeltaTime, 0)
                    : new Vector3(Speed * Time.fixedDeltaTime, 0);
        }
        else
        {
            transform.position +=
                moveTowardsStart
                    ? new Vector3(0f, -Speed * Time.fixedDeltaTime)
                    : new Vector3(0f, Speed * Time.fixedDeltaTime);
        }
        MoveObjectBetweenPoints();
    }

    void OnDrawGizmosSelected()
    {
        DetermineIfMoveDirectionIsHorizontal();
        Gizmos.color = Color.blue;
        SetStartAndStopPosition();
        Vector3 startVector =
            isHorizontal
                ? new Vector3(start, transform.position.y, transform.position.z)
                : new Vector3(transform.position.x,
                    start,
                    transform.position.z);

        Vector3 endVector =
            isHorizontal
                ? new Vector3(stop, transform.position.y, transform.position.z)
                : new Vector3(transform.position.x, stop, transform.position.z);
        Gizmos.DrawLine (startVector, endVector);
    }

    void SetStartAndStopPosition()
    {
        start =
            isHorizontal
                ? transform.position.x - startDistance
                : transform.position.y - startDistance;
        stop =
            isHorizontal
                ? transform.position.x + stopDistance
                : transform.position.y + stopDistance;
    }

    void DetermineIfMoveDirectionIsHorizontal()
    {
        isHorizontal = direction == Direction.HORIZONTAL;
    }

    void FlipGameObjectHorizontal()
    {
        if (shouldFlip)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    void MoveObjectBetweenPoints()
    {
        if (isHorizontal)
        {
            if (transform.position.x <= start)
            {
                moveTowardsStart = false;
                FlipGameObjectHorizontal();
            }
            else if (transform.position.x >= stop)
            {
                moveTowardsStart = true;
                FlipGameObjectHorizontal();
            }
        }
        else
        {
            if (transform.position.y <= start)
            {
                moveTowardsStart = false;
            }
            else if (transform.position.y >= stop)
            {
                moveTowardsStart = true;
            }
        }
    }
}

public enum Direction
{
    HORIZONTAL,
    VERTICAL
}
