using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    float level;
    // Start is called before the first frame update
    void Start()
    {
        level = HubManager.instance.currentlevel;
         m_TextMeshPro.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        level = HubManager.instance.currentlevel;
        m_TextMeshPro.text = level.ToString();
    }
}
