public class RedMushroom : Mushroom
{
    public override void HandlePickup(){
        EventManager.RedMushroomPickupEvent?.Invoke();
        HideItem();
        
    }
}
