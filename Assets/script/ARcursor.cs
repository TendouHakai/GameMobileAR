using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARcursor : MonoBehaviour
{
    public GameObject Arcursor;
    public GameObject OjectPortal;
    public ARRaycastManager RaycastManager;

    private bool isUseCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        Arcursor.SetActive(isUseCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if(isUseCursor)
        {
            updateCursor();
        }

        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if (isUseCursor)
            {
                GameObject gameObject =  GameObject.Instantiate(OjectPortal, transform.position, transform.rotation);

                Destroy(gameObject, 2);
            }
        }
    }

    void updateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count > 0 )
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
