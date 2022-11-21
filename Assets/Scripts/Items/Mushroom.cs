using UnityEngine;

public class Mushroom : Item
{
    [SerializeField]
    AudioSource mushroomSpawnSound = null;

    [SerializeField]
    MoveForward moveForward = null;

    [SerializeField]
    Rigidbody2D rigidbody = null;

    [SerializeField]
    protected BoxCollider2D mushroomCollider = null;

    [SerializeField]
    BoxCollider2D mushroomTrigger = null;

    public override void HandlePickup()
    {
        throw new System.NotImplementedException();
    }

    void Awake()
    {
        Spawn();
        Invoke("MoveMushroom", 1.0f);
    }

    void MoveMushroom()
    {
        mushroomCollider.enabled = true;

        if (moveForward)
        {
            moveForward.enabled = true;
        }
        if (rigidbody)
        {
            rigidbody.WakeUp();
        }
        if (mushroomTrigger)
        {
            mushroomTrigger.enabled = true;
        }
        if (rigidbody)
        {
            rigidbody.gameObject.transform.parent = null;
        }
    }

    public virtual void Spawn()
    {
        if (mushroomSpawnSound != null)
        {
            mushroomSpawnSound.Play();
        }
    }
}
