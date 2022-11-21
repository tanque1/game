using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField]
    protected Animator blockAnimator = null;

    [SerializeField]
    protected AudioSource blockHitSound = null;

    [SerializeField]
    protected BlockTrigger blockTrigger = null;

    [SerializeField]
    protected GameObject triggerObject = null;

    [SerializeField]
    protected GameObject colliderObject = null;

    protected virtual void Awake()
    {
        if (blockTrigger != null)
        {
            blockTrigger.PlayerHitBlockEvent += HandlePlayerHitBlock;
        }
    }

    protected void OnDestroy()
    {
        if (blockTrigger != null)
        {
            blockTrigger.PlayerHitBlockEvent -= HandlePlayerHitBlock;
        }
    }

    public virtual void HandlePlayerHitBlock()
    {
        colliderObject.SetActive(true);
        triggerObject.SetActive(false);
        blockAnimator.Play(Animations.HIT);
    }
}
