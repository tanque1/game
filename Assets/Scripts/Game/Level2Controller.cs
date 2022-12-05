using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    float timer = 2.0f;

    bool played = false;

    private void Start()
    {
        EventManager.StartLevel2IntroSequence?.Invoke();
    }

    void FixedUpdate()
    {
        if (played)
        {
            return;
        }

        timer -= Time.fixedDeltaTime;

        if (timer <= 0)
        {
            EventManager.StopLevel2IntroSeQuence?.Invoke();
            played = true;
        }
    }
}
