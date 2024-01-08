using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OxygenBar : MonoBehaviour
{
    public AstronautPlayer player;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void UpdateOxygenBar() {

        slider.value = Mathf.Clamp(GameManager.Instance.getPlayerO2Level() / AstronautPlayer.MAX_O2_LEVEL, 0, 1f);
        
        //healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
    }
}

