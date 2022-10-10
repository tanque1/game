using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator = null;

    public void SetFireMario()
    {
        animator.Play(Animations.MARIO_FIRE_STATE);
    }

    public void SetBigMario()
    {
        animator.Play(Animations.MARIO_BIG_STATE);
    }

    public void SetRegularMario()
    {
        animator.Play(Animations.MARIO_REGULAR_STATE);
    }

    public void PlayMarioIdleAnimation()
    {
        HandleMarioStateChange(Animations.FIRE_MARIO_IDLE,
        Animations.BIG_MARIO_IDLE,
        Animations.IDLE);
    }

    public void PlayMarioRunAnimation()
    {
        HandleMarioStateChange(Animations.FIRE_MARIO_RUN,
        Animations.BIG_MARIO_RUN,
        Animations.RUN);
    }

    public void PlayMarioJumpAnimation()
    {
        HandleMarioStateChange(Animations.FIRE_MARIO_JUMP,
        Animations.BIG_MARIO_JUMP,
        Animations.JUMP);
    }

    public void PlayMarioStompAnimation()
    {
        HandleMarioStateChange(Animations.FIRE_MARIO_STOMP,
        Animations.BIG_MARIO_STOMP,
        Animations.STOMP);
    }

    public void PlayMarioSwimAnimation()
    {
        HandleMarioStateChange(Animations.FIRE_MARIO_SWIM,
        Animations.BIG_MARIO_SWIM,
        Animations.SWIM);
    }

    public void PlayMarioHitFlagAnimation()
    {
        HandleMarioStateChange(Animations.FIRE_MARIO_HIT_FLAG,
        Animations.BIG_MARIO_HIT_FLAG,
        Animations.HIT_FLAG);
    }

    public void PlayMarioLoseLifeAnimation()
    {
        animator.Play(Animations.MARIO_LOSE_LIFE);
    }

    private void HandleMarioStateChange(
        string fireMarioAnim,
        string bigMarioAnim,
        string regularMarioAnim
    )
    {
        if (GameState.Mode == GameState.PlayerMode.FIRE)
        {
            animator.Play (fireMarioAnim);
        }
        else if (GameState.Mode == GameState.PlayerMode.BIG)
        {
            animator.Play (bigMarioAnim);
        }
        else
        {
            animator.Play(regularMarioAnim);
        }
    }
}
