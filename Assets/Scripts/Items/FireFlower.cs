public class FireFlower : Item
{
    public override void HandlePickup()
    {
        EventManager.FireFlowerPickupEvent?.Invoke();
        HideItem();
    }
}
