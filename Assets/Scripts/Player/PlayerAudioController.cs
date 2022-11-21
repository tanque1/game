using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField]
    AudioSource damageSound = null;

    [SerializeField]
    AudioSource jumpSound = null;

    [SerializeField]
    AudioSource flagSound = null;

    [SerializeField]
    AudioSource loseLifeSound = null;

    [SerializeField]
    AudioSource finishedLevelSound = null;

    public void PlayDamageSound()
    {
        damageSound.Play();
    }

    public void PlayJumpSound()
    {
        jumpSound.Play();
    }

    public void PlayFlagSound()
    {
        flagSound.Play();
    }

    public void PlayLoseLifeSound()
    {
        loseLifeSound.Play();
    }

    public void PlayFinishedLevelSound()
    {
        finishedLevelSound.Play();
    }
}
