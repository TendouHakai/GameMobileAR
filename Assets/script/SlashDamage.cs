using System.Collections;
using UnityEngine;

public class SlashDamage : MonoBehaviour
{
    public SkinnedMeshRenderer render;
    public Color SlashColor;
    public float SlashTime;
    private Color OrigColor;
    // Start is called before the first frame update
    void Start()
    {
        OrigColor = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //if(IsSlash)
        //{
        //    StartCoroutine(Slash());
        //}
    }

    public void SlashStart()
    {
        render.material.color = SlashColor;
    }

    void SlashEnd()
    {
        render.material.color = OrigColor;
    }

    public IEnumerator Slash()
    {
        SlashStart();
        yield return new WaitForSeconds(SlashTime);
        SlashEnd();
    }
}
