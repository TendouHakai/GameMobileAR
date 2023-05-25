using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] trackedObejcts;
    public GameObject helpMapTranform;
    public List<GameObject> BorderRadarObjects;
    // Start is called before the first frame update
    void Start()
    {
        BorderRadarObjects = new List<GameObject> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBorderRadarObjects()
    {

    }
}
