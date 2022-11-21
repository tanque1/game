using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Controller : MonoBehaviour
{
    [SerializeField]
    GameObject player = null;

    [SerializeField]
    GameObject spawnPoint2 = null;

    [SerializeField]
    AudioSource music = null;

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        EventManager.MegaMushroomPickupEvent += PauseMusic;
        EventManager.MegaMarioBackToRegularSizeEvent += UnpauseMusic;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        EventManager.MegaMushroomPickupEvent -= PauseMusic;
        EventManager.MegaMarioBackToRegularSizeEvent -= UnpauseMusic;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.isPipeInLevel1)
        {
            SetMarioPosition();
        }
    }

    void SetMarioPosition()
    {
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        rigidbody.position = spawnPoint2.transform.position;
    }

    void PauseMusic()
    {
        music.Pause();
    }

    void UnpauseMusic()
    {
        music.Play();
    }
}
