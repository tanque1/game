using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldIntroController : MonoBehaviour
{
    GameObject worldNumberObject = null;

    GameObject worldNameObject = null;

    GameObject livesObject = null;

    TextMeshProUGUI worldNameText;

    TextMeshProUGUI worldNumberText;

    TextMeshProUGUI livesText;

    void OnEnable()
    {
        worldNameObject = GameObject.Find("WorldNameText");
        worldNumberObject = GameObject.Find("WorldNumberText");
        livesObject = GameObject.Find("LivesNumber");
        Debug.Log (livesObject);
        if (worldNumberObject != null)
        {
            worldNumberText = worldNumberObject.GetComponent<TextMeshProUGUI>();
        }

        if (worldNameObject != null)
        {
            worldNameText = worldNameObject.GetComponent<TextMeshProUGUI>();
        }

        if (livesObject != null)
        {
            livesText = livesObject.GetComponent<TextMeshProUGUI>();
            Debug.Log(livesText);
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
                LevelController
                    .levelIntroNumbers[LevelController.index]
                    .ToString();
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
