using System;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Action EnemyTriggerHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
        Debug.Log(EnemyTriggerHit);
            EnemyTriggerHit?.Invoke();
        }
    }
}
