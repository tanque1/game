using UnityEngine;

public class MrBlizzard : AI, IBreakable
{
    [SerializeField]
    Animator animator = null;

    [SerializeField]
    Transform spawnPoint = null;

    [SerializeField]
    GameObject snowBall = null;

    [SerializeField]
    EnemyTrigger enemyTrigger = null;

    [SerializeField]
    GameObject collider = null;

    [SerializeField]
    Rigidbody2D rigidbody = null;

    GameObject player;

    bool triggerHit;

    void Start()
    {
        enemyTrigger.EnemyTriggerHit += HandleTriggerHit;
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        InvokeRepeating("ThrowSnowball", 0f, 2.0f);
    }

    void OnDestroy()
    {
        enemyTrigger.EnemyTriggerHit -= HandleTriggerHit;
    }

    void HandleTriggerHit()
    {
        triggerHit = true;
        rigidbody.isKinematic = true;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        collider.gameObject.SetActive(false);
        enemyTrigger.gameObject.SetActive(false);
        animator.Play(Animations.MR_BLIZZARD_DIE);
        Die();

        Invoke("DestroyGameObject", 1.0f);
    }

    void DestroyGameObject()
    {
        Destroy (gameObject);
    }

    void Update()
    {
        if (player != null)
        {
            bool isPlayerToTheLeft =
                transform.position.z > player.transform.position.x;
            transform.rotation =
                isPlayerToTheLeft
                    ? Quaternion.Euler(0, 0, 0)
                    : Quaternion.Euler(0, 180, 0);
        }
    }

    void ThrowSnowball()
    {
        if (!triggerHit)
        {
            Attack();
            animator.Play(Animations.THROW_SNOWBALL);
            Invoke("PlayThrow", 0.6f);
            Invoke("PlayIdle", 1.0f);
        }
    }

    void PlayIdle()
    {
        if (!triggerHit)
        {
            animator.Play("Idle");
        }
    }

    void PlayThrow()
    {
        if (!triggerHit)
        {
            Instantiate(snowBall,
            spawnPoint.position,
            Quaternion.Euler(0, 0, 0));
        }
    }

    public void Break(){
        collider.gameObject.SetActive(false);
        rigidbody.AddForce(new Vector3(1,1,0));
        Die();
    }
}
