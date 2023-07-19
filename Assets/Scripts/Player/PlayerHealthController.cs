using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PlayerHealthController : MonoBehaviour
{
    public GameObject damagedLevel;

    public UnityEngine.UI.Image damageControl;
    public static PlayerHealthController Instance { get; private set; }

    [field: Header("Health")]
    [field: SerializeField] public float MaxHealthPoints {get; private set;}
    [field: SerializeField] public float HealthPoints { get; private set; }
    [SerializeField] private float HealSpeed = 2f;

    

    [Header("Cooldown")]
    [SerializeField] private float RegenCoooldown = 4f;
    [SerializeField] private bool IsRegenInCooldown = false;

    [Header("Tests")]
    [SerializeField] private bool hit = false;

    private WaitForSeconds HealDelay;
    private WaitForSeconds RegenCooldownDelay;
    private Coroutine SetRegenCoroutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
 //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        HealDelay = new WaitForSeconds(2f);
        RegenCooldownDelay = new WaitForSeconds(RegenCoooldown);

        MaxHealthPoints = 20;
        HealthPoints = 20;

        StartCoroutine(HealthLogic());
        // ReceiveDamage(20);
    }

    private void Update()
    {
        if (hit == true)
        {
            ReceiveDamage(20);
            hit = false;
        }
    }

    IEnumerator SetRegenCooldown()
    {
        IsRegenInCooldown = true;
        yield return RegenCooldownDelay;
        IsRegenInCooldown = false;
        SetRegenCoroutine = null;
    }

    IEnumerator HealthLogic()
    {
        while (true)
        {
            if (IsRegenInCooldown)
            {
                yield return new WaitUntil(() => IsRegenInCooldown == false);
            }
            
            if(HealthPoints < MaxHealthPoints)
            {
                HealthPoints += HealSpeed;
                yield return HealDelay;
            }
            else
            {
                yield return null;
            }
        }
    }

    public float GetHealthPercentage()
    {
        return (float)HealthPoints / MaxHealthPoints;
    }

    public void FixedUpdate()
    {
        damageControl = damagedLevel.GetComponent<UnityEngine.UI.Image>();

        damageControl.color = new Color(damageControl.color.r, damageControl.color.g, damageControl.color.b, (MaxHealthPoints - HealthPoints) * 0.01f);
    }

    public void ReceiveDamage(int damage)
    {
        CameraShake.Instance.ShakeCamera(30f, 1.2f);

        HealthPoints -= damage;

        if(HealthPoints <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }

        if (SetRegenCoroutine != null) StopCoroutine("SetRegenCooldown");
        SetRegenCoroutine = StartCoroutine("SetRegenCooldown");

    }
}