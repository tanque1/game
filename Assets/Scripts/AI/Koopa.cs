using UnityEngine;

public class Koopa : AI, IBreakable
{
    [SerializeField]
    protected Animator animator = null;

    [SerializeField]
    MoveController moveForward = null;

    [SerializeField]
    protected Rigidbody2D rigidBody = null;

    [SerializeField]
    protected GameObject koopaWalkingColliderObject = null;

    [SerializeField]
    protected GameObject koopaWalkingTriggerObject = null;

    [SerializeField]
    protected GameObject koopaShellColliderObject = null;

    [SerializeField]
    protected GameObject koopaShellTriggerObject = null;

    [SerializeField]
    protected EnemyCollider koopaWalkingCollider = null;

    [SerializeField]
    protected EnemyTrigger koopaWalkingTrigger = null;

    [SerializeField]
    protected EnemyCollider koopaShellCollider = null;

    [SerializeField]
    protected EnemyTrigger koopaShellTrigger = null;

    protected int state = 2;

    protected virtual void Start()
    {
        if (koopaWalkingTrigger != null)
        {
            koopaWalkingTrigger.EnemyTriggerHit += HandleKoopaWalkingTriggerHit;
        }
        if (koopaShellTrigger != null)
        {
            koopaShellTrigger.EnemyTriggerHit += HandleKoopaShellTriggerHit;
        }
    }

    protected virtual void OnDestroy()
    {
        if (koopaWalkingTrigger != null)
        {
            koopaWalkingTrigger.EnemyTriggerHit -= HandleKoopaWalkingTriggerHit;
        }
        if (koopaShellTrigger != null)
        {
            koopaShellTrigger.EnemyTriggerHit -= HandleKoopaShellTriggerHit;
        }
    }

    protected virtual void ChangeState()
    {
        switch (state)
        {
            case 2:
                HandleMoveState();
                SetKoopaWalkingTriggerActive();
                break;
            case 1:
                HandleShellState();
                break;
            case 0:
                HandleShellSlideState();
                break;
        }
    }

    protected void SetKoopaWalkingTriggerActive()
    {
        if (koopaWalkingTriggerObject != null)
        {
            koopaShellTriggerObject.SetActive(true);
        }
    }

    protected void HandleMoveState()
    {
        moveForward.enabled = true;
        if (koopaWalkingColliderObject != null)
        {
            koopaWalkingColliderObject.SetActive(true);
        }
        if (koopaWalkingTriggerObject != null)
        {
            koopaWalkingTriggerObject.SetActive(true);
        }
        if (koopaShellColliderObject != null)
        {
            koopaShellColliderObject.SetActive(false);
        }
        if (koopaShellTriggerObject != null)
        {
            koopaShellTriggerObject.SetActive(false);
        }
    }

    protected void HandleShellState()
    {
        moveForward.enabled = false;
        if (koopaWalkingColliderObject != null)
        {
            koopaWalkingColliderObject.SetActive(false);
        }
        if (koopaWalkingTriggerObject != null)
        {
            koopaWalkingTriggerObject.SetActive(false);
        }
        if (koopaShellColliderObject != null)
        {
            koopaShellColliderObject.SetActive(true);
        }
        if (koopaShellTriggerObject != null)
        {
            koopaShellTriggerObject.SetActive(true);
        }
    }

    protected void HandleShellSlideState()
    {
        moveForward.enabled = true;
    }

    protected void HandleKoopaWalkingTriggerHit()
    {
        state = 1;
        ChangeState();
        animator.Play(Animations.KOOPA_SHELL_IDLE);
        Die();
    }

    protected void HandleKoopaShellTriggerHit()
    {

        state = 0;
        ChangeState();
        animator.Play(Animations.KOOPA_SHELL);
        moveForward.Speed *= 2;
        Invoke("EnableShellCollider", 0.5f);
    }

    public virtual void Break()
    {
        HandleKoopaWalkingTriggerHit();
        koopaShellColliderObject.SetActive(false);
        rigidBody.AddForce(new Vector3(1, 1, 0));
    }
}
