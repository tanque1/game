using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    protected Animator itemAnimator;

    [SerializeField]
    protected AudioSource itemPickupSound;

    [SerializeField]
    SpriteRenderer spriteRenderer = null;

    [SerializeField]
    BoxCollider2D collider = null;

    protected const string COLLECT = "Collect";

    public abstract void HandlePickup();

    protected void HideItem()
    {
        spriteRenderer.enabled = false;
    }

    public void EnableCollider()
    {
        collider.enabled = true;
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            DisableCollider();
            HandlePickup();
            if (itemAnimator != null)
            {
                itemAnimator?.Play(COLLECT);
            }
            if (itemPickupSound != null)
            {
                itemPickupSound?.Play();
            }

            Destroy(gameObject, 2.0f);
        }
    }
}
