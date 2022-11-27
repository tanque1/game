#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
using UnityEngine;

public class FlyingKoopa : Koopa
{
    [SerializeField]
    Rigidbody2D rigidbody2D = null;

    [SerializeField]
    GameObject koopaFlyingColliderObject = null;

    [SerializeField]
    GameObject koopaFlyingTriggerObject = null;

    [SerializeField]
    EnemyTrigger koopaFlyingTrigger = null;


#if UNITY_EDITOR
    [SerializeField]
    AnimatorController regularKoopaAnimator = null;
#endif


    int state = 3;

    protected override void Start()
    {
        koopaFlyingTrigger.EnemyTriggerHit += HandleKoopaFlyingTriggerHit;

        if (koopaWalkingTrigger != null)
        {
            koopaWalkingTrigger.EnemyTriggerHit += HandleKoopaWalkingTriggerHit;
        }
        if (koopaShellTrigger != null)
        {
            koopaShellTrigger.EnemyTriggerHit += HandleKoopaShellTriggerHit;
        }
    }

    private void OnDestroy()
    {
        koopaFlyingTrigger.EnemyTriggerHit -= HandleKoopaFlyingTriggerHit;

        if (koopaWalkingTrigger != null)
        {
            koopaWalkingTrigger.EnemyTriggerHit -= HandleKoopaWalkingTriggerHit;
        }
        if (koopaShellTrigger != null)
        {
            koopaShellTrigger.EnemyTriggerHit -= HandleKoopaShellTriggerHit;
        }
    }

    protected override void ChangeState()
    {
        switch (state)
        {
            case 3:
                Fly();
                break;
            case 2:
                HandleMoveState();
                Invoke("SetKoopaWalkingTriggerActive", 1.0f);
                break;
            case 1:
                HandleShellState();
                break;
            case 0:
                HandleShellSlideState();
                break;
        }
    }

    void HandleKoopaFlyingTriggerHit()
    {
        rigidbody2D.gravityScale = 1;
        state = 2;
        ChangeState();
        koopaFlyingColliderObject.SetActive(false);
        koopaFlyingTriggerObject.SetActive(false);


#if UNITY_EDITOR
        animator.runtimeAnimatorController = regularKoopaAnimator;
#endif

    }

    public void Fly()
    {
        koopaFlyingColliderObject.SetActive(true);
        koopaFlyingTriggerObject.SetActive(true);
    }

    public void Break()
    {
        HandleKoopaFlyingTriggerHit();
        HandleKoopaWalkingTriggerHit();
        koopaShellColliderObject.SetActive(false);
        rigidBody.AddForce(new Vector3(1, 1, 0));
    }
}
