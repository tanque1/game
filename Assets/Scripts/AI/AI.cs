using UnityEngine;

public abstract class AI : MonoBehaviour
{
    [SerializeField]
    protected bool doesEnemyAttack = false;

    [SerializeField]
    protected AudioSource dieSound = null;

    [SerializeField]
    protected AudioSource attackSound = null;

    public virtual void Die()
    {
        if (dieSound != null)
        {
            dieSound.Play();
        }
    }

    public virtual void Attack()
    {
        if (doesEnemyAttack)
        {
            if (attackSound != null)
            {
                attackSound.Play();
            }
        }
    }
}
