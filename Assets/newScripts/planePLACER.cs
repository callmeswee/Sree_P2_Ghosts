using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
    
    [RequireComponent(typeof(ARRaycastManager))]

public class planePLACER : MonoBehaviour
{
    private ARPlaneManager m_ARPlaneManager;

    private ARRaycastManager m_Raycastmanager;
    static List <ARRaycastHit> s_hits = new List<ARRaycastHit> ();
    private bool _planesFound;

    private int _objPlacedIndex;

    public List<GameObject> VisualElements;
    

    private void Awake()
    {
        m_Raycastmanager = GetComponent<ARRaycastManager>();
        m_ARPlaneManager = GetComponent<ARPlaneManager>();

    }
    

    // Update is called once per frame
    void Update()
    {
        if(!_planesFound){
            ScanPlanes();
        }
        else{
            PlaceObject();
        }
    }

    private void ScanPlanes()
    {
        if(m_ARPlaneManager.trackables.count > 0)
        _planesFound = true;
     }

     private void PlaceObject()
     {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                if(m_Raycastmanager.Raycast(touch.position,s_hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_hits[0].pose;
                    SetVisualElement(hitPose);
                }
            }

        }
     }

      private void SetVisualElement(Pose hitPose)
       {
        if (_objPlacedIndex < VisualElements.Count)
        {
            Instantiate(VisualElements[_objPlacedIndex], hitPose.position, hitPose.rotation);
        }
        else{
            HidePlanes();
        }
        _objPlacedIndex++;

        }

        private void HidePlanes(){
            foreach (var plane in m_ARPlaneManager.trackables)
            {
            Debug.Log("planes should be going off");
            plane.gameObject.SetActive(false);
             }
        }
}


