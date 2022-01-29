using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{

    [SerializeField] private Vector2 parallaxEffectMultiplier;      //Multiplier on the speed that the background follows the camera

    private Transform cameraTransform;                              //Setting the transform of the camera
    private Vector3 lastCameraPosition;                             //Setting the specific vector 3 for the location of the camera

    private void Start()
    {
        cameraTransform = Camera.main.transform;                    //Setting the camera transform to be the camera transform
        lastCameraPosition = cameraTransform.position;              //Putting the camera position on the 'last camera position' so that it can be used in the update part of the script
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;      //Get the sprite renderer component
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
    }
}
