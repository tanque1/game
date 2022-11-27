using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject livesObject;

    GameObject coinsObject;

    GameObject starsObject;

    TextMeshProUGUI livesText;

    TextMeshProUGUI coinsText;

    TextMeshProUGUI starsText;

    GameObject backgroundObject;

    Image backgroundImage;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateLivesText();
        UpdateCoinsText();
        UpdateStarsText();
        livesObject = GameObject.Find("LivesText");
        coinsObject = GameObject.Find("CoinsText");
        starsObject = GameObject.Find("StarsText");
        backgroundObject = GameObject.Find("HorizontalGroup");

        if (livesObject)
        {
            livesText = livesObject.GetComponent<TextMeshProUGUI>();
        }

        if (coinsObject)
        {
            coinsText = coinsObject.GetComponent<TextMeshProUGUI>();
        }

        if (starsObject)
        {
            starsText = starsObject.GetComponent<TextMeshProUGUI>();
        }

        if (backgroundObject)
        {
            backgroundImage = backgroundObject.GetComponent<Image>();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject levelCameraObject = GameObject.Find(Strings.LEVEL_CAMERA);
        if (levelCameraObject)
        {
            Camera levelCamera = levelCameraObject.GetComponent<Camera>();
            if (levelCamera)
            {
                backgroundImage.color = levelCamera.backgroundColor;
                UpdateCoinsText();
                UpdateLivesText();
                UpdateStarsText();
            }
        }
    }

    void Start()
    {
        EventManager.CoinPickupEvent += UpdateCoinsText;
        EventManager.StarPickupEvent += UpdateStarsText;
        EventManager.LivesPickupEvent += UpdateLivesText;
    }

    void Destroy()
    {
        EventManager.CoinPickupEvent -= UpdateCoinsText;
        EventManager.StarPickupEvent -= UpdateStarsText;
        EventManager.LivesPickupEvent -= UpdateLivesText;
    }

    public void UpdateLivesText()
    {
        if (GameState.Lives >= 0 && livesText)
        {
            livesText.SetText(GameState.Lives.ToString());
        }
    }

    public void UpdateCoinsText()
    {
        if (coinsText)
        {
            coinsText.SetText(GameState.Coins.ToString());
        }
    }

    public void UpdateStarsText()
    {
        if (starsText)
        {
            starsText.SetText(GameState.Stars.ToString());
        }
    }
}
