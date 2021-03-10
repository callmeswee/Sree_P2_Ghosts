using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionManager : MonoBehaviour
{
    public LayerMask interactableLayer;

    private Camera mainCamera;
    private Interactable currentInteractable;
    private Vector3 startTouchPosition;
    private float startInteractDistance;



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        DetectFingerInEditor();
#else
        DetectFingerInPhone();
#endif
    }

    private void DetectFingerInEditor()
    {
        Ray ray;
        RaycastHit hit;
        // First down
        if(Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 50f, interactableLayer))
            {
                //maybe hit a interactable
                Interactable interactable = hit.rigidbody.GetComponent<Interactable>();
                if (interactable)
                {
                    // really hit an interactable
                    currentInteractable = interactable;
                    startInteractDistance = hit.distance;

                    //inform interactbable with the touch possition

                    startTouchPosition = mainCamera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, startInteractDistance));
                    currentInteractable.OnTouchDown(startTouchPosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //reset
            if(currentInteractable)
            {
                currentInteractable.OnTouchUp();

            }
            currentInteractable = null;
        }
    }

    private void DetectFingerInPhone()
    {
        if (Input.touchCount == 0)
        {
            if (currentInteractable)
            {
                currentInteractable.OnTouchUp();
            }
            currentInteractable = null;
            return;
        }


        Ray ray;
        RaycastHit hit;
        Vector3 touchPosition = Input.GetTouch(0).position;

        // First down
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = mainCamera.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out hit, 50f, interactableLayer))
            { 
                //maybe hit a interactable
                Interactable interactable = hit.rigidbody.GetComponent<Interactable>();
                if (interactable)
                {
                    // really hit an interactable
                    currentInteractable = interactable;
                    startInteractDistance = hit.distance; 

                    //inform interactbable with the touch possition

                    startTouchPosition = mainCamera.ScreenToViewportPoint(new Vector3(touchPosition.x, touchPosition.y, startInteractDistance));
                    currentInteractable.OnTouchDown(startTouchPosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //reset
            if (currentInteractable)
            {
                currentInteractable.OnTouchUp();

            }
            currentInteractable = null;
        }

    }
}
