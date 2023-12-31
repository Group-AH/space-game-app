using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public AstronautPlayer player;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void UpdateHealthBar() {

        slider.value = Mathf.Clamp(GameManager.Instance.getPlayerHealth() / AstronautPlayer.MAX_HEALTH, 0, 1f);
        
        //healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
    }

}
