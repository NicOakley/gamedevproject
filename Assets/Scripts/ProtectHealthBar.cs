using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProtectHealthBar : MonoBehaviour
{

    private Image healthBar;
    public static float MAX_HEALTH = 100;
    public static float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / MAX_HEALTH;

        
    }
}
