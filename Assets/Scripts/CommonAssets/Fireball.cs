using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D = null;

    [SerializeField]
    int speed = 100;

    [SerializeField]
    float timer = 2.0f;

    bool isMarioFacingRightWhenSpawned;

    void Start()
    {
        isMarioFacingRightWhenSpawned = GameState.IsMarioFacingRight;
        MoveFireBall();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy (gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (
            collision.gameObject.tag.Equals(Tags.DAMAGE) ||
            collision
                .gameObject
                .transform
                .parent
                .gameObject
                .tag
                .Equals(Tags.DAMAGE)
        )
        {
            try
            {
                collision.gameObject.SendMessage("Break");
                collision.gameObject.transform.parent.SendMessage("Break");
                collision
                    .gameObject
                    .transform
                    .parent
                    .parent
                    .SendMessage("Break");
            }
            catch (Exception e)
            {
            }
            Destroy (gameObject);
        }
        else
        {
            MoveFireBall();
        }
    }

    private void MoveFireBall()
    {
        if (isMarioFacingRightWhenSpawned)
        {
            rigidbody2D.AddForce(Vector2.right * speed);
        }
        else
        {
            rigidbody2D.AddForce(-Vector2.right * speed);
        }
    }
}
