using UnityEngine;
using UnityEngine.UI;

public class WorldIntroController : MonoBehaviour
{
    GameObject worldNumberObject;

    GameObject worldNameObject;

    GameObject livesObject;

    Text worldNameText;

    Text worldNumberText;

    Text livesText;

    void OnEnable()
    {
        worldNameObject = GameObject.Find("WorldNameText");
        worldNumberObject = GameObject.Find("WorldNumberText");
        livesObject = GameObject.Find("LivesNumber");

        if (worldNumberObject)
        {
            worldNumberText = worldNumberObject.GetComponent<Text>();
        }

        if (worldNameObject)
        {
            worldNameText = worldNameObject.GetComponent<Text>();
        }

        if (livesObject)
        {
            livesText = livesObject.GetComponent<Text>();
        }

        UpdateWorldNumberText();
        UpdateWorldNameText();
        UpdateWorldLives();
    }

    void UpdateWorldNumberText()
    {
        if (worldNumberText)
        {
            worldNumberText.text =
                LevelController.levelIntroNumbers[LevelController.index].ToString();
        }
    }

    void UpdateWorldLives()
    {
        if (livesText)
        {
            livesText.text = GameState.Lives.ToString();
        }
    }

    void UpdateWorldNameText()
    {
        if (worldNameText)
        {
            worldNameText.text =
                LevelController.levelIntroNames[LevelController.index];
        }
    }
}
