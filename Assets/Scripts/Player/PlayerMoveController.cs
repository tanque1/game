using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransForm = null;

    [SerializeField]
    Rigidbody2D rigidbody2D = null;

    bool isJumping = false;

    bool isMoving = false;

    bool isStomping = false;

    public bool IsMarioJumping()
    {
        return isJumping;
    }

    public bool IsMarioStomping()
    {
        return isStomping;
    }

    public bool IsMarioMoving()
    {
        return isMoving;
    }

    public void SetMarioJumpingValue(bool Jumping)
    {
        isJumping = Jumping;
    }

    public void SetMarioStompingValue(bool Stomping)
    {
        isStomping = Stomping;
    }

    public void SetMarioMovingValue(bool Moving)
    {
        isMoving = Moving;
    }

    public void TurnMarioLeft()
    {
        playerTransForm.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void TurnMarioRight()
    {
        playerTransForm.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetMarioIdle()
    {
        SetMarioMovingValue(false);
    }

    public void AddForceRight(int force)
    {
        rigidbody2D.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
    }

    public void AddForceLeft(int force)
    {
        rigidbody2D.AddForce(new Vector2(-force, 0), ForceMode2D.Impulse);
    }

    public void AddForceUp(int force)
    {
        rigidbody2D.AddForce(new Vector2(0, force));
    }

    public void AddForceDown(int force)
    {
        rigidbody2D.AddForce(new Vector2(0, -force));
    }

    public void FreezeMarioXPosition()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void FreezeMarioRotation()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void UnfreezeMarioConstraints()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }
}
