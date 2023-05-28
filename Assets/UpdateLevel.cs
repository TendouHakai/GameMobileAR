using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    public bool isCurrentLevel = true;
    float level;
    // Start is called before the first frame update
    void Start()
    {
        if (isCurrentLevel)
            level = HubManager.instance.currentlevel;
        else level = HubManager.instance.Completedlevel;
         m_TextMeshPro.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrentLevel)
            level = HubManager.instance.currentlevel;
        else level = HubManager.instance.Completedlevel;
        m_TextMeshPro.text = level.ToString();
    }
}
