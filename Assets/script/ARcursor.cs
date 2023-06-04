using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARcursor : MonoBehaviour
{
    public static ARcursor instance;
    public GameObject Arcursor;
    public GameObject OjectPortal;
    public ARRaycastManager RaycastManager;
    public ARPlaneManager PlaneManager;
    [SerializeField] private Camera camera;

    public bool isUseCursor = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Arcursor.SetActive(isUseCursor);
        //foreach (var plane in PlaneManager.trackables)
        //{
        //    plane.gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (isUseCursor)
        {
            updateCursor();
        }
    }

    void updateCursor()
    {
        Vector2 screenPosition = camera.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count > 0 )
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }

        
    }

    public void placeThePortal()
    {
        isUseCursor = false;
        PlaneManager.enabled = false;
        foreach (var plane in PlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        GameObject gameObject = Instantiate(OjectPortal, transform.position, transform.rotation);
        SpawnManager.instance.spawnPosition = gameObject.transform;
        ScreenManager.instance.ResumeGame();
        Debug.Log("Create portal successfully");
        Arcursor.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
