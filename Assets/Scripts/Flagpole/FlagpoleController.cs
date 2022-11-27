using System.Collections.Generic;
using UnityEngine;

public class FlagpoleController : MonoBehaviour, IBreakable
{
    [SerializeField]
    BoxCollider2D collider = null;

    [SerializeField]
    BoxCollider2D trigger = null;

    [SerializeField]
    AudioSource breakSound = null;

    [SerializeField]
    GameObject brokenObject = null;

    [SerializeField]
    SpriteRenderer originalSprite = null;

    [SerializeField]
    List<Rigidbody2D> debrisObjects = null;

    bool isBroken = false;

    void Update()
    {
        collider.gameObject.SetActive(GameState.IsInvincible && !isBroken);
    }

    public void Break()
    {
        isBroken = true;
        originalSprite.enabled = false;
        trigger.gameObject.SetActive(false);
        collider.gameObject.SetActive(false);
        brokenObject.SetActive(true);
        breakSound.Play();
        foreach (Rigidbody2D rigidbody in debrisObjects)
        {
            if (GameState.IsMarioFacingRight)
            {
                rigidbody.AddForce(Vector2.right * 500);
                rigidbody.gameObject.transform.rotation =
                    Quaternion.Euler(0, 0, 270);
            }
            else
            {
                rigidbody.AddForce(-Vector2.right * 500);
                rigidbody.gameObject.transform.rotation =
                    Quaternion.Euler(0, 0, 90);
            }

            rigidbody.AddForce(-Vector2.up * 550);
        }
    }
}
