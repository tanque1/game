using UnityEngine;

public class LoadLevelController : MonoBehaviour
{
   [SerializeField] string nameOfLevelToLoad = null;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals(Tags.Player)){
            enabled = false;
            GameManager.LoadScene(nameOfLevelToLoad);
            GameManager.LoadUI();
            GameManager.HandleLevel1Reloaded();
            
        }
    }

}
