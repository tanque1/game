using UnityEngine;

public class FrostPiranha : AI, IBreakable
{
    [SerializeField] GameObject collider = null;

    public void Break(){
        collider.gameObject.SetActive(false);
        Die();
    }
}
