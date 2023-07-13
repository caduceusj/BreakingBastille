using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    
    [SerializeField] private Transform player;

    private Renderer render;
    private Color _Color;

    private NavMeshAgent agent;

    void Awake()
    {
        render = gameObject.GetComponentInChildren<Renderer>();
        _Color = render.material.color;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = player.position;
    }

    private IEnumerator HitEffect()
    {
        render.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        render.material.color = _Color;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        StartCoroutine(HitEffect());

        if (currentHealth <= 0)
        { Death(); }
    }

    void Death()
    {
        // Death function
        // TEMPORARY: Destroy Object
        Destroy(gameObject);
    }
}
