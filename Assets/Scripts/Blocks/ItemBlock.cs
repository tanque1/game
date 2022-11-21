using UnityEngine;

public class ItemBlock : Block, IBreakable
{
    [SerializeField]
    ItemType itemType;

    [SerializeField]
    FireFlower fireFlower = null;

    [SerializeField]
    RedMushroom redMushroom = null;

    [SerializeField]
    OneUpMushroom oneUpMushroom = null;

    [SerializeField]
    MegaMushroom megaMushroom = null;



    public void Break()
    {
        base.HandlePlayerHitBlock();
        blockHitSound.Play();
        colliderObject.SetActive(false);
        switch (itemType)
        {
            case ItemType.FIRE_FLOWER:
                RevealItem (fireFlower);
                break;
            case ItemType.RED_MUSHROOM:
                RevealItem (redMushroom);
                break;
            case ItemType.ONE_UP_MUSHROOM:
                RevealItem (oneUpMushroom);
                break;
            case ItemType.MEGA_MUSHROOM:
                RevealItem (megaMushroom);
                break;
        }
        colliderObject.SetActive(true);
    }

    public override void HandlePlayerHitBlock()
    {
        base.HandlePlayerHitBlock();
        Invoke("RevealItem", 0.6f);
    }

    public void RevealItem()
    {
        blockAnimator.Play(Animations.ITEM_REVEAL);
        blockHitSound.Play();
        switch (itemType)
        {
            case ItemType.FIRE_FLOWER:
                fireFlower.gameObject.SetActive(true);
                break;
            case ItemType.RED_MUSHROOM:
                redMushroom.gameObject.SetActive(true);
                break;
            case ItemType.ONE_UP_MUSHROOM:
                oneUpMushroom.gameObject.SetActive(true);
                break;
            case ItemType.MEGA_MUSHROOM:
                megaMushroom.gameObject.SetActive(true);
                break;
        }
    }

    void RevealItem(Item item)
    {
        item.gameObject.SetActive(true);
        item.gameObject.transform.parent = null;
        Rigidbody2D rigidbody = item.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(0, -20), ForceMode2D.Impulse);
        item.EnableCollider();
    }

    public enum ItemType
    {
        FIRE_FLOWER,
        RED_MUSHROOM,
        ONE_UP_MUSHROOM,
        MEGA_MUSHROOM
    }
}
