using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class PlayerMovimentation : MonoBehaviour
{
    GameObject singleButton, doubleButton;
    public float smooth;
    bool singleControlButton;
    private void Update()
    {
        if (singleControlButton)
        {
            singleButton.SetActive(true);
            doubleButton.SetActive(false);
        }
        if (doubleButton)
        {
            singleButton.SetActive(false);
            doubleButton.SetActive(true);
        }
    }
   
    public void RotateRight()
    {
        transform.Rotate(Vector3.forward, 90f);
        ClampRotation();
    }


    public void RotateLeft()
    {
        transform.Rotate(Vector3.forward, -90f);
        ClampRotation();
    }

    
    private void ClampRotation()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float yRotation = currentRotation.z;

        float roundedRotation = Mathf.Round(yRotation / 90) * 90f;
       
        Quaternion rot = Quaternion.Euler(currentRotation.x, currentRotation.y, roundedRotation);
       
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, smooth);
    }
}
