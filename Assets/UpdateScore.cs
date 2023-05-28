using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        score = HubManager.instance.score;
        m_TextMeshPro.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score = HubManager.instance.score;
        m_TextMeshPro.text = score.ToString();
    }
}
