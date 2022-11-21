using UnityEngine;

public class EnterPipeController : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D pipeCollider = null;

    [SerializeField]
    AudioSource audioSource = null;

    bool isPlayerCollidingWithEnterPipeTrigger = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.PLAYER))
        {
            isPlayerCollidingWithEnterPipeTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals(Tags.PLAYER)){
            isPlayerCollidingWithEnterPipeTrigger = false;
        }
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.DownArrow) && isPlayerCollidingWithEnterPipeTrigger){
           audioSource.Play();
           Invoke("DropIntoPipe", 0.5f); 
        }
    }

    void DropIntoPipe(){
        pipeCollider.enabled = false;
    }
}
