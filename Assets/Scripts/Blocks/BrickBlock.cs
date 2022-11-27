using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : Block, IBreakable
{
    [SerializeField]
    SpriteRenderer spriteRenderer = null;

    [SerializeField]
    GameObject debris = null;

    [SerializeField]
    List<Rigidbody2D> debrisObjects = null;

    [SerializeField]
    AudioSource blockBreakAudio = null;

    [SerializeField]
    AudioSource coinCollectAudio = null;

    [SerializeField]
    BlockType blockType;

    [SerializeField]
    GameObject coin = null;

    [SerializeField]
    GameObject blockBrick = null;

    bool hit;

    int numCoins;

    protected override void Awake()
    {
        base.Awake();
        switch (blockType)
        {
            case BlockType.EMPTY:
                numCoins = 0;
                coin.SetActive(false);
                break;
            case BlockType.ONE_COIN:
                numCoins = 1;
                coin.SetActive(true);
                break;
            case BlockType.MANY_COINS:
                numCoins = 5;
                coin.SetActive(true);
                break;
        }
    }

    public override void HandlePlayerHitBlock()
    {
        if (blockType == BlockType.EMPTY)
        {
            HandleEmptyBlockHit();
        }
        else if (
            blockType == BlockType.ONE_COIN || blockType == BlockType.MANY_COINS
        )
        {
            HandleCoinBlockHit();
        }
    }

    void HandleEmptyBlockHit()
    {
        if (hit) return;

        if (coin)
        {
            coin.SetActive(false);
        }
        hit = true;
        blockBreakAudio.Play();
        colliderObject.SetActive(false);
        triggerObject.SetActive(false);
        debris.SetActive(true);
        spriteRenderer.enabled = false;
        foreach (Rigidbody2D rigidbody in debrisObjects)
        {
            rigidbody.AddRelativeForce(Random.onUnitSphere * 200);
        }
        Invoke("HandleDestroy", 0.5f);
    }

    void HandleDestroy()
    {
        Destroy (blockBrick);
    }

    void HandleCoinBlockHit()
    {
        if (hit) return;

        coinCollectAudio.Play();
        GameState.Coins++;
        EventManager.CoinPickupEvent?.Invoke();
        blockAnimator.Play(Animations.HIT);
        numCoins--;

        Invoke("SetIdle", 0.2f);
    }

    public void SetIdle()
    {
        if (numCoins == 0)
        {
            hit = true;
            blockAnimator.Play(Animations.FINISHED);
            triggerObject.SetActive(false);
            colliderObject.SetActive(true);
        }
        else
        {
            blockAnimator.Play(Animations.IDLE);
        }
    }

    public void Break()
    {
        if (blockType == BlockType.SOLID && !GameState.IsInvincible)
        {
            return;
        }

        HandleEmptyBlockHit();
    }
}

public enum BlockType
{
    EMPTY,
    ONE_COIN,
    MANY_COINS,
    SOLID
}
