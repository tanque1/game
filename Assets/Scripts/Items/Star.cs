public class Star : Item{
    public override void HandlePickup(){
        GameState.Stars++;
        EventManager.StarPickupEvent?.Invoke();
        HideItem();
    }
}
