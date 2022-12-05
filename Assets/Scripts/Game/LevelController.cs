using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static List<string>
        levelIntroNumbers =
            new List<string> {
                Strings.WORLD_1,
                Strings.WORLD_2,
                Strings.WORLD_3,
                Strings.WORLD_4,
                Strings.WORLD_5,
                Strings.WORLD_6,
                Strings.WORLD_7
            };

    public static int index = 0;

    public static List<string>
        levelIntroNames =
            new List<string> {
                Strings.WORLD_1_NAME,
                Strings.WORLD_2_NAME,
                Strings.WORLD_3_NAME,
                Strings.WORLD_4_NAME,
                Strings.WORLD_5_NAME,
                Strings.WORLD_6_NAME,
                Strings.WORLD_7_NAME
            };

    public static List<string>
        levels =
            new List<string> {
                Scenes.LEVEL1,
                Scenes.LEVEL2,
                Scenes.SKY_LEVEL,
                Scenes.SNOW_LEVEL,
                Scenes.GRAVEYARD,
                Scenes.WATER_LEVEL,
                Scenes.BOWSER_CASTLE
            };

    public void LoadIntroForNextLevel()
    {
        GameManager.UnloadUI();
        GameManager.LoadScene(Scenes.WORLD_INTRO);
        Invoke("LoadNextLevel", 1.5f);
    }

    public void LoadNextLevel(){
        GameManager.LoadScene(levels[index]);
        GameManager.LoadUI();
        index++;
    }
}
