using UnityEngine;

public class MovingPlatformCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
