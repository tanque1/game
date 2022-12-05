using UnityEngine;

public class DestroyOnLoad : MonoBehaviour
{
    [SerializeField]
    float timeout;

    private void Start()
    {
        Invoke("DestroyObject", timeout);
    }

    void DestroyObject()
    {
        Destroy (gameObject);
    }
}
