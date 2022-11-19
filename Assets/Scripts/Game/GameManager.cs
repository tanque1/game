using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPipeInLevel1;

    public static GameObject Mario;

    public PlayerManager playerManager;

    private void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
        playerManager = Mario.GetComponent<PlayerManager>();
    }

    void Start()
    {
        EventManager.FireFlowerPickupEvent += HandleFireFlowerPickup;
        EventManager.RedMushroomPickupEvent += HandleRedMushroomPickupEvent;
    }

    void OnDestroy()
    {
        EventManager.FireFlowerPickupEvent -= HandleFireFlowerPickup;
        EventManager.RedMushroomPickupEvent -= HandleRedMushroomPickupEvent;
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
    }

    public static void LoadUI()
    {
    }

    public static void HandleLevel1Reloaded()
    {
    }
}
