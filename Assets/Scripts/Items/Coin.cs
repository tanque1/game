public class Coin : Item
{
    public override void HandlePickup()
    {
        GameState.Coins++;
        EventManager.CoinPickupEvent?.Invoke();
        Invoke("HideItem", 0.2f);
    }
}
