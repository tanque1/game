using UnityEngine;

public class LoadLevelController : MonoBehaviour
{
   [SerializeField] string nameOfLevelToLoad = null;

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag.Equals(Tags.PLAYER)){
            enabled = false;
            GameManager.LoadScene(nameOfLevelToLoad);
            GameManager.LoadUI();
            GameManager.HandleLevel1Reloaded();
        }
    }

}
 