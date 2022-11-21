using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D = null;

    public float Speed;

    private void FixedUpdate()
    {
        rigidbody2D
            .AddForce(transform.right * Time.fixedDeltaTime * -Speed * 5,
            ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (
            !collision.gameObject.tag.Equals(Tags.PLAYER) &&
            !collision.gameObject.tag.Equals(Tags.GROUND)
        )
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
