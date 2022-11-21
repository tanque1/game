using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class OptionsScreen : MonoBehaviour
{
    GameObject livesSliderObject;
    GameObject audioButtonObject;
    GameObject backToMainMenuObject;
    GameObject audioButtonTextObject;
    GameObject livesTextObject;

    Slider livesSlider;
    Button audioButton;
    Button backToMainMenuButton;
    TextMeshProUGUI audioButtonText;
    TextMeshProUGUI livesText;

    private void Start (){
        livesSliderObject = GameObject.Find("LivesSlider");
        audioButtonObject = GameObject.Find("AudioButton");
        backToMainMenuObject = GameObject.Find("BackToMainMenuButton");
        audioButtonTextObject = GameObject.Find("AudioButtonText");
        livesTextObject = GameObject.Find("LivesValue");

        if(livesSliderObject){
            livesSlider = livesSliderObject.GetComponent<Slider>();
        }
        
        if(audioButtonObject){
            audioButton = audioButtonObject.GetComponent<Button>();
        }

        if(backToMainMenuObject){
            backToMainMenuButton = backToMainMenuObject.GetComponent<Button>();
        }

        if(audioButtonTextObject){
            audioButtonText = audioButtonTextObject.GetComponent<TextMeshProUGUI>();
        }

        if(livesTextObject){
            livesText = livesTextObject.GetComponent<TextMeshProUGUI>();
        }

        if(livesSlider){
            livesSlider.onValueChanged.AddListener(HandleSliderValueChanged);
        }

        if(audioButton){
            audioButton.onClick.AddListener(HandleAudioButtonClicked);
        }

        if(backToMainMenuButton){
            backToMainMenuButton.onClick.AddListener(HandleBackToMainMenuButtonClicked);
        }
    }

    private void OnDestroy(){
        if(livesSlider){
            livesSlider.onValueChanged.RemoveListener(HandleSliderValueChanged);
        }

        if(audioButton){
            audioButton.onClick.RemoveListener(HandleAudioButtonClicked);
        }

        if(backToMainMenuButton){
            backToMainMenuButton.onClick.RemoveListener(HandleBackToMainMenuButtonClicked);
        }
    }

    public void HandleSliderValueChanged(float value){
        int lives = (int) value;
        GameState.Lives = lives;
        if(livesText){
            livesText.SetText(lives.ToString());
        }
    }

    public void HandleAudioButtonClicked(){
        GameState.AudioEnabled = !GameState.AudioEnabled;
        if(GameState.AudioEnabled){
                SetAudioButtonColorAndText(Colors.GREEN,"On");
                UnmuteAllSound();
        }
        else{
            SetAudioButtonColorAndText(Colors.RED,"Off");
            MuteAllSound();	
        }
    }

    private void HandleBackToMainMenuButtonClicked() {
        SceneManager.LoadSceneAsync(Scenes.MAIN_MENU);
        SceneManager.UnloadSceneAsync(Scenes.OPTIONS_SCREEN);
    }

    public void SetAudioButtonColorAndText(Color color, string text){
        if(audioButton){
            audioButton.targetGraphic.color = color;
        }

        if(audioButtonText){
            audioButtonText.SetText(text);
        }
    }

    public void MuteAllSound(){
        AudioListener.volume = 0;
    }
    public void UnmuteAllSound(){
        AudioListener.volume = 1;
    }



}
