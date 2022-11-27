using UnityEngine;
using System;
public class EnemyCollider : MonoBehaviour
{
    public Action MarioGotHitByEnemy;
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag.Equals(Tags.PLAYER)){
            MarioGotHitByEnemy?.Invoke();
        }
    }
}
