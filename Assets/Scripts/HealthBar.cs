using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image healthBar;
    public float MAX_HEALTH = 100;
    public float health = 50;

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
