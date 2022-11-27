using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPipeInLevel1;

    public static GameObject Mario;

    private PlayerManager playerManager;

    [SerializeField]
    PauseMenu pauseMenu = null;

    bool isPaused = false;

    [SerializeField]
    LevelController levelController = null;

    bool isStartScreen = true;

    GameObject level1CameraObject;

    Camera level1Camera;

    CameraMove cameraMoveScript;

    void Start()
    {
        EventManager.FireFlowerPickupEvent += HandleFireFlowerPickup;
        EventManager.RedMushroomPickupEvent += HandleRedMushroomPickupEvent;
        EventManager.StartButtonClicked += HandleStartButtonClicked;
        EventManager.NewGameEvent += LoadNewGame;
        EventManager.OptionsEvent += LoadOptionsScreen;
        EventManager.RestartCurrentLevelEvent += RestartCurrentLevelWithDelay;
        EventManager.FreezeCameraEvent += FreezeCamera;
        EventManager.StopPlayingAllAudioEvent += StopAllPlayingAudio;

        EventManager.LoadNextLevelEvent += HandleLoadNextLevel;

        // EventManager.StartLevel2IntroSequence += HandleStartLevel2IntroSequence;
        // EventManager.StopLevel2IntroSeQuence += HandleStopLevel2IntroSeQuence;
        SceneManager.activeSceneChanged += HandleSceneWasChanged;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStartScreen)
        {
            HandleStartButtonClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void OnDestroy()
    {
        EventManager.FireFlowerPickupEvent -= HandleFireFlowerPickup;
        EventManager.RedMushroomPickupEvent -= HandleRedMushroomPickupEvent;
        EventManager.StartButtonClicked -= HandleStartButtonClicked;
        EventManager.NewGameEvent -= LoadNewGame;
        EventManager.OptionsEvent -= LoadOptionsScreen;
        EventManager.RestartCurrentLevelEvent -= RestartCurrentLevelWithDelay;
        EventManager.FreezeCameraEvent -= FreezeCamera;
        EventManager.StopPlayingAllAudioEvent -= StopAllPlayingAudio;

        EventManager.LoadNextLevelEvent -= HandleLoadNextLevel;

        // EventManager.StartLevel2IntroSequence -= HandleStartLevel2IntroSequence;
        // EventManager.StopLevel2IntroSeQuence -= HandleStopLevel2IntroSeQuence;
        SceneManager.activeSceneChanged -= HandleSceneWasChanged;
    }

    private void HandleLoadNextLevel()
    {
        levelController.LoadIntroForNextLevel();
    }

    void HandleFireFlowerPickup()
    {
        if (playerManager != null)
        {
            playerManager.HandleMarioFireMode();
        }
    }

    void HandleRedMushroomPickupEvent()
    {
        if (playerManager != null)
        {
            playerManager.HandleMarioBigMode();
        }
    }

    public static void LoadScene(string name)
    {
        SceneManager.LoadScene (name);


#if UNITY_ANDROID || UNITY_IOS
        SceneManager.LoadSceneAsync(Scenes.CONTROLLER, LoadSceneMode.Additive);
#endif

    }

    public static void LoadUI()
    {
        SceneManager.LoadSceneAsync(Scenes.UI, LoadSceneMode.Additive);
    }

    public static void UnloadUI()
    {
        try
        {
            SceneManager.UnloadSceneAsync(Scenes.UI);
        }
        catch (ArgumentException e)
        {
            Debug.LogException (e);
        }
    }

    public static void HandleLevel1Reloaded()
    {
        isPipeInLevel1 = true;
    }

    private void RestartCurrentLevel()
    {
        if (GameState.Lives == -1)
        {
            LoadScene(Scenes.GAME_OVER);
        }
        else
        {
            LoadScene(GameState.CurrentLevel);
        }
        LoadUI();
    }

    void TogglePauseMenu()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pauseMenu.Show();
        }
        else
        {
            pauseMenu.Hide();
        }
    }

    void HandleStartButtonClicked()
    {
        if (isStartScreen)
        {
            isStartScreen = false;
            SceneManager.UnloadSceneAsync(Scenes.START_SCREEN);


#if UNITY_ANDROID || UNITY_IOS
            SceneManager
                .LoadSceneAsync(Scenes.MAIN_MENU, LoadSceneMode.Additive);
#else
        SceneManager.LoadSceneAsync(Scenes.MAIN_MENU);
#endif
        }
    }

    void LoadNewGame()
    {
        levelController.LoadIntroForNextLevel();
        SceneManager.UnloadSceneAsync(Scenes.MAIN_MENU);
    }

    void LoadOptionsScreen()
    {
        SceneManager.LoadSceneAsync(Scenes.OPTIONS_SCREEN);
        SceneManager.UnloadSceneAsync(Scenes.MAIN_MENU);
    }

    void HandleSceneWasChanged(Scene current, Scene next)
    {
        GameState.IsInvincible = false;
        GameState.CurrentLevel = next.name;
        Mario = GameObject.Find(Strings.MARIO);
        if (GameState.IsWaterLevel)
        {
            GameState.IsWaterLevel = false;
        }
        if (Mario)
        {
            playerManager = Mario.GetComponent<PlayerManager>();
        }
        level1CameraObject = GameObject.Find(Strings.LEVEL_CAMERA);
        if (level1CameraObject != null)
        {
            level1Camera = level1CameraObject.GetComponent<Camera>();
            cameraMoveScript = level1CameraObject.GetComponent<CameraMove>();
            if (level1Camera != null)
            {
                GameObject currentMainCamera =
                    GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA);

                if (currentMainCamera != null)
                {
                    currentMainCamera.tag = Tags.UNTAGGED;
                }
                level1Camera.tag = Tags.MAIN_CAMERA;
            }
        }
    }

    private void RestartCurrentLevelWithDelay()
    {
        Invoke("RestartCurrentLevel", 2.5f);
    }

    private void FreezeCamera()
    {
        if (cameraMoveScript)
        {
            cameraMoveScript.enabled = false;
        }
    }

    private void StopAllPlayingAudio()
    {
        AudioSource[] allAudioSource = FindObjectsOfType<AudioSource>();
        foreach (var audio in allAudioSource)
        {
            audio.Stop();
        }
    }
}
