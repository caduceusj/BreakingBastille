using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance { get; private set; }

    [field: Header("Health")]
    [field: SerializeField] public int MaxHealthPoints {get; private set;}
    [field: SerializeField] public int HealthPoints { get; private set; }
    [SerializeField] private int HealSpeed = 1;

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
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        HealDelay = new WaitForSeconds(0.5f);
        RegenCooldownDelay = new WaitForSeconds(RegenCoooldown);

        MaxHealthPoints = 20;
        HealthPoints = 20;

        StartCoroutine(HealthLogic());
        ReceiveDamage(20);
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
        return HealthPoints * 100 / MaxHealthPoints;
    }

    public void ReceiveDamage(int damage)
    {
        Debug.Log("levei Dano");
        HealthPoints -= damage;

        if(SetRegenCoroutine != null) StopCoroutine("SetRegenCooldown");
        SetRegenCoroutine = StartCoroutine("SetRegenCooldown");

    }
}
