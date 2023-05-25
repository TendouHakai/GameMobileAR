using System.Collections;
using System.Collections.Generic;
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

    public void setHealth(int health)
    {
        this.health = health;
        healthBarSlider.value = this.health;
    }

    public void TakeDamge()
    {
        this.health--;
        healthBarSlider.value = this.health;
        var color = gotHurtSCreen.GetComponent<Image>().color;
        color.a = 0.6f;

        gotHurtSCreen.GetComponent<Image>().color = color;
    }

}