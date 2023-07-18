using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Image healthBar;


    public float fillSpeed = 3f, healthPercent;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthPercent = PlayerHealthController.Instance.GetHealthPercentage();



        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, healthPercent, Time.deltaTime * fillSpeed);
    }
}
