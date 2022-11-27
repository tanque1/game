using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    Animator animator = null;

    [SerializeField]
    int height;

    [SerializeField]
    AudioSource audioSource = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            if (audioSource)
            {
                audioSource.Play();
            }
            animator.Play(Animations.SPRING);
            GameObject player = collision.gameObject;
            Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                rigidbody2D
                    .AddForce(new Vector2(0, height), ForceMode2D.Impulse);
                Invoke("ResetSpring", 1.0f);
            }
        }
    }

    private void ResetSpring()
    {
        animator.Play(Animations.IDLE);
    }
}
