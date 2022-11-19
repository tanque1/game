
public class OneUpMushroom : Mushroom
{
    public override void HandlePickup(){
        GameState.Lives++;
        EventManager.LivesUpdatedEvent?.Invoke();
        HideItem();
    }
}
