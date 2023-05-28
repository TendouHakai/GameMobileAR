using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] public Slider healthBarSlider;
    public GameObject gotHurtSCreen;
    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(gotHurtSCreen != null)
        {
            if(gotHurtSCreen.GetComponent<Image>().color.a>0) {
                var color = gotHurtSCreen.GetComponent<Image>().color;
                color.a -= 0.005f;
                gotHurtSCreen.GetComponent<Image>().color = color;
            }
        }
    }

    public override void setHealth(int health)
    {
        this.health = health;
        healthBarSlider.value = this.health;
    }

    public override void TakeDamge()
    {
        this.health--;
        healthBarSlider.value = this.health;
        if(this.health<=0)
        {
            ScreenManager.instance.gameOver();
            return;
        }
        AudioManager.instance.PlaySFX("Take Damage");
        var color = gotHurtSCreen.GetComponent<Image>().color;
        color.a = 0.6f;

        gotHurtSCreen.GetComponent<Image>().color = color;
    }

}
