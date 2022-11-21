using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    float xOffset;

    float yOffset;

    float zOffset;

    float priorYOffset;


    void Start()
    {
        EventManager.MegaMushroomPickupEvent += MegaMarioSettings;
        EventManager.MegaMarioBackToRegularSizeEvent += RegularMarioSettings;
        xOffset = offset.x;
        yOffset = offset.y;
        priorYOffset = yOffset;
        zOffset = offset.z;
    }

    void OnDestroy()
    {
        EventManager.MegaMushroomPickupEvent -= MegaMarioSettings;
        EventManager.MegaMarioBackToRegularSizeEvent -= RegularMarioSettings;
    }

    private void Update()
    {

        if (GameManager.Mario != null)
        {
            transform.position =
                new Vector3(xOffset + GameManager.Mario.transform.position.x,
                    GameManager.Mario.transform.position.y + yOffset,
                    zOffset);
        }
    }

    void MegaMarioSettings (){
        yOffset = 0;
    }

    void RegularMarioSettings(){
        yOffset = priorYOffset;
    }
}
