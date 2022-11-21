using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour, IBreakable
{
    [SerializeField]
    Rigidbody2D rigidbody = null;

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
    List<Rigidbody2D> debrisObject = null;

    public void Break()
    {
        originalSprite.enabled = false;
        trigger.gameObject.SetActive(false);
        brokenObject.SetActive(true);
        breakSound.Play();

        foreach (Rigidbody2D rigidbody in debrisObject)
        {
            if (GameState.IsMarioFacingRight)
            {
                rigidbody.AddForce(Vector2.right * 1500);
                rigidbody.gameObject.transform.rotation =
                    Quaternion.Euler(0, 0, 270);
            }
            else
            {
                rigidbody.AddForce(-Vector2.right * 1500);
                rigidbody.gameObject.transform.rotation =
                    Quaternion.Euler(0, 0, 90);
            }
        }
    }
}
