using UnityEngine;

public class FlagpoleCollider : MonoBehaviour
{
    [SerializeField]
    AudioSource clearedLevelAudio = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            clearedLevelAudio.Play();
            EventManager.FinishedLevelEvent?.Invoke();
        }
    }
}
