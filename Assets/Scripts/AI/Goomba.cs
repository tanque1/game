using UnityEngine;

public class Goomba : AI, IBreakable
{
    [SerializeField]
    Animator animator = null;

    [SerializeField]
    Rigidbody2D rigidbody = null;

    [SerializeField]
    EnemyCollider goombaCollider = null;

    [SerializeField]
    EnemyTrigger goombaTrigger = null;

    [SerializeField]
    MoveController moveController = null;

    private void Start()
    {
        goombaTrigger.EnemyTriggerHit += HandleGoombaTriggerHit;
    }

    private void OnDestroy()
    {
        goombaTrigger.EnemyTriggerHit -= HandleGoombaTriggerHit;
    }

    void HandleGoombaTriggerHit()
    {
        moveController.enabled = false;
        rigidbody.isKinematic = true;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        goombaCollider.gameObject.SetActive(false);
        goombaTrigger.gameObject.SetActive(false);
        animator.Play(Animations.GOOMBA_SQUASH);
        Die();
        Invoke("DestroyGameObject", 1.0f);
    }

    void DestroyGameObject()
    {
        Destroy (gameObject);
    }

    public void Break()
    {
        goombaCollider.gameObject.SetActive(false);
        rigidbody.AddForce(new Vector3(1, 1, 0));
        Die();
    }
}
