using UnityEngine;

public class GameState
{
    public static int Lives { get; set; }

    public static bool AudioEnabled { get; set; }

    public static int Coins { get; set; }

    public static int Stars { get; set; }

    public static PlayerMode Mode { get; set; }

    public static string CurrentLevel { get; set; }

    public static bool IsInvincible { get; set; }

    public static bool IsWaterLevel { get; set; }

    public static bool IsMarioFacingRight { get; set; }

    void Awake()
    {
        Lives = 3;
        Mode = PlayerMode.REGULAR;
        AudioEnabled = true;
        IsMarioFacingRight = true;
    }

    public enum PlayerMode
    {
        REGULAR,
        BIG,
        FIRE
    }
}
