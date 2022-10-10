using System;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField]
    GameObject smallMarioCollider = null;

    [SerializeField]
    GameObject bigMarioCollider = null;

    public Action MarioHitGround;

    public Action MarioGotHitByEnemy;

    public Action<Collision2D> MarioIsCollidingWithObject;

    public void MarioGotBigger()
    {
        smallMarioCollider.SetActive(false);
        bigMarioCollider.SetActive(true);
    }

    public void MarioGotSmaller()
    {
        bigMarioCollider.SetActive(false);
        smallMarioCollider.SetActive(true);
    }

    public void MarioGotSmallerWithDelay()
    {
        Invoke("MarioGotSmaller", 2.0f);
    }

    public void DisableMarioColliders()
    {
        bigMarioCollider.SetActive(false);
        smallMarioCollider.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.GROUND))
        {
            MarioHitGround?.Invoke();
        }
        else if (
            collision.gameObject.tag.Equals(Tags.DAMAGE) &&
            !GameState.IsInvincible
        )
        {
            MarioGotHitByEnemy?.Invoke();
        }
        else if (collision.gameObject.tag.Equals(Tags.END_LEVEL))
        {
            EventManager.LoadNextLevelEvent?.Invoke();
        }

        MarioIsCollidingWithObject?.Invoke(collision);
    }
}
