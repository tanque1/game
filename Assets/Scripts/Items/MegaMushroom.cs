
public class MegaMushroom : Mushroom
{
    public override void HandlePickup(){
        EventManager.MegaMushroomPickupEvent?.Invoke();
        HideItem();
    }
}
