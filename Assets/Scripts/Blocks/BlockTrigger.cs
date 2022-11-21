using System;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    public Action PlayerHitBlockEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            PlayerHitBlockEvent?.Invoke();
        }
    }
}
