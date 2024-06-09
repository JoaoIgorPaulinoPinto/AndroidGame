using UnityEngine;
using UnityEngine.UI;

public class PlayerMovimentation : MonoBehaviour
{
    private bool isRotating = false;
    private Vector2 previousTouchPosition;
    public  float rotationSpeed = 0.1f;

    [SerializeField] GameObject singleButton, doubleButton;

    public float smooth;
    public bool singleControl, dragControl, doubleControl;
    private void Update()
    {
        ControltypeManager();
        if (dragControl)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    previousTouchPosition = touch.position;
                    isRotating = true;
                }
                else if (touch.phase == TouchPhase.Moved && isRotating)
                {
                    Vector2 direction = touch.position - previousTouchPosition;
                    float rotationZ = -direction.x * rotationSpeed;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotationZ) * transform.rotation;
                    previousTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isRotating = false;
                }
            }
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

    void ControltypeManager()
    {
        string controltype = PlayerPrefs.GetString("control type");
        switch (controltype)
        {
            case "SingleControlType":
                singleControl = true;
                doubleControl = false;
                dragControl = false;

                singleButton.SetActive(true);
                doubleButton.SetActive(false);

                break;
            case "DragControlType":
                singleControl = false;
                doubleControl = false;
                dragControl = true;

                singleButton.SetActive(false);
                doubleButton.SetActive(false);
                break;
            case "DoubleControlType":
                singleControl = false;
                doubleControl = true;
                dragControl = false;

                singleButton.SetActive(false);
                doubleButton.SetActive(true);
                break;
            default:
                // Se não houver nenhum tipo salvo, assume-se o controle de arrastar
                singleControl = false;
                doubleControl = true;
                dragControl = false;

                singleButton.SetActive(false);
                doubleButton.SetActive(true);
                break;
        }
    }
}

