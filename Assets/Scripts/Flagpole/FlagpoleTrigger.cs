using UnityEngine;

public class FlagpoleTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals(Tags.PLAYER) && !GameState.IsInvincible){
            EventManager.JumpedOnFlagEvent?.Invoke();
        }
    }
}
