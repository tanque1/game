using UnityEngine;

public class MegaMarioController : MonoBehaviour
{
    [SerializeField]
    GameObject mario = null;

    [SerializeField]
    AudioSource hereWeGoSource = null;

    [SerializeField]
    AudioSource megaMarioMusic = null;

    float timer = 20.0f;

    void Start()
    {
        mario.transform.localScale *= 2;
        hereWeGoSource.Play();
        Invoke("PlayerMegaMarioMusic", 1.0f);
        GameState.IsInvincible = true;
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            mario.transform.localScale /= 2;
            enabled = false;
            StopMegaMarioMusic();
            EventManager.MegaMarioBackToRegularSizeEvent?.Invoke();
        }
    }

    void PlayerMegaMarioMusic()
    {
        megaMarioMusic.Play();
    }

    void StopMegaMarioMusic()
    {
        megaMarioMusic.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameState.IsInvincible)
        {
            // collision.gameObject.SendMessage("Break");
            // collision.gameObject.transform.parent.SendMessage("Break");
            // collision.gameObject.transform.parent.parent.SendMessage("Break");
        }
    }
}
