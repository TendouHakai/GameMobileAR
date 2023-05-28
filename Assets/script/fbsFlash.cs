using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fbsFlash : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        StartBlinking();
    }
    IEnumerator Blink()
    {
        while (true)
        {
            switch (text.activeInHierarchy)
            {
                case true:
                    text.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case false:
                    text.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }

    }

    void StartBlinking()
    {
        StopCoroutine(Blink());
        StartCoroutine(Blink());
    }
    void StopBlinking()
    {
        StopCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
