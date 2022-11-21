using System.Collections.Generic;

using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] AudioSource audioSource1 = null;
    [SerializeField] AudioSource audioSource2 = null;
    [SerializeField] List<Light> lights = null;
    int currentIndex = 0;

    void Start(){
        UpdateDisplay();
        EventManager.AButtonClicked += HandleMenuOptionSelected;
        EventManager.MoveUpClicked += HandleUpPressed;
        EventManager.MoveDownClicked += HandleDownPressed;

    }

    private void OnDestroy(){
        EventManager.AButtonClicked -= HandleMenuOptionSelected;
        EventManager.MoveUpClicked -= HandleUpPressed;
        EventManager.MoveDownClicked -= HandleDownPressed;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            HandleUpPressed();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){
            HandleDownPressed(); 
        }
        else if(Input.GetKeyDown(KeyCode.Return)){
            if(currentIndex == 0){
                audioSource1.Play();
            }
            else if(currentIndex == 1){
                audioSource2.Play();
            }

            animator.Play("OutTro");
            Invoke("HandleMenuOptionSelected",1.5f);
        }
    }

    void UpdateDisplay(){
        for(int i = 0; i<lights.Count; i++){
            lights[i].enabled = currentIndex == i ? true : false;
        }
    }

    void HandleMenuOptionSelected(){
        switch (currentIndex)
        {
            case 0: 
                HandleNewGameSelected();
                break;
            case 1: 
                HandleOptionSelected();
                break;
            default:
                break;
        }
    }

    void HandleNewGameSelected(){
        EventManager.NewGameEvent.Invoke();
    }

    void HandleOptionSelected(){
        EventManager.OptionsEvent.Invoke();
    }

    void HandleUpPressed(){
        currentIndex = currentIndex > 0 ? currentIndex - 1 : lights.Count - 1;
        UpdateDisplay(); 
    }
    void HandleDownPressed(){
        currentIndex = currentIndex < lights.Count - 1  ? currentIndex + 1 : 0;
        UpdateDisplay();
    }

}
