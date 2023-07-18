using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private ParticleSystem blood;
    [SerializeField] private int bloodParticle;
    [field: SerializeField] public int damagePower { get; private set;  }
    
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;

    public float FollowRange = 5;

    private Renderer render;
    public  NavMeshAgent agent;
    private Animator anim;

    private Color _Color;
    private bool playerInRange = false;
    private bool canFollow = true;

    public bool canAttack { get; set; }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("canAttack", true);

        currentHealth = maxHealth;
    }

    private void Start()
    {
        render = gameObject.GetComponentInChildren<Renderer>();
        player = GameObject.FindWithTag("Player").transform;
     
        _Color = render.material.color;
    }

    private void Update()
    {
        // if(!playerInRange) trackPlayer();
        trackPlayer();

        if (anim.GetBool("canAttack"))
        {
            canAttack = true;
            agent.isStopped = false;
            // agent.speed = 3.5f;
        }
        else
        {
            agent.isStopped = true;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Gizmos.color = transparentGreen;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), FollowRange);
    }
    public void trackPlayer()
    {
        bool playerInRange = Physics.CheckSphere(transform.position, FollowRange, playerLayer, QueryTriggerInteraction.Ignore);

        if(playerInRange)
        {
            transform.LookAt(new Vector3(player.position.x, this.transform.position.y, player.position.z));
            agent.destination = player.position;
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                anim.SetFloat("speed", .66f, .2f, Time.deltaTime);
            }
            else
            {
                anim.SetFloat("speed", 1, .2f, Time.deltaTime);
                attack();
            }
        }
        else
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                if (anim.GetFloat("speed") < 0.01) anim.SetFloat("speed", .0f);
                else anim.SetFloat("speed", .0f, .2f, Time.deltaTime);
            }
        }

    }

    private void attack()
    {
        // anim.SetBool("canAttack", false);
        // agent.speed = 0;
        
        anim.SetTrigger("isAttacking");

       

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
        blood.Play();
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
