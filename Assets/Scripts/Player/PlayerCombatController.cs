using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{
    private InputStarterAssets input;
    private InputStarterAssets.PlayerActions player;

    [Header("Attacking")]
    [SerializeField] private float attackDistance = 3f;
    [SerializeField] private float attackDelay = 0.4f;
    [SerializeField] private float attackSpeed = 1f;
    [field: SerializeField] public int attackDamage { get; set; }
    [SerializeField] private LayerMask attackLayer;

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private AudioClip swordSwing;
    [SerializeField] private AudioClip hitSound;

    bool attacking = false;
    public bool canAttack { get; set; }
    bool readyToAttack = true;
    int attackCount;

    [Header("Camera")]
    [SerializeField] private Camera cam;

    public Animator animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        input = new InputStarterAssets();
        player = input.Player;
        AssignInputs();
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("canAttack", false);
        
        attackDamage = 1;
        canAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("canAttack"))
        {
            canAttack = true;
            // agent.speed = 3.5f;
        }
    }


    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

    void AssignInputs()
    {
        /*input.Jump.performed += ctx => Jump();*/
        player.Attack.started += ctx => Attack();
    }

    public void Attack()
    {
        if (!readyToAttack || attacking) return;

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        
        animator.SetTrigger("isAttacking");
        // Invoke(nameof(AttackRaycast), attackDelay);

        if (attackCount == 0)
        {
            // ChangeAnimationState(ATTACK1);
            attackCount++;
        }
        else
        {
            // ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * attackDistance, Color.green, 10f);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            print("Attacked!");
            // HitTarget(hit.point);

            if (hit.transform.TryGetComponent<EnemyController>(out EnemyController T)) { 

                T.TakeDamage(attackDamage); 
            }
        }
    }

    void HitTarget(Vector3 pos)
    {
        GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(GO, 20);
    }
}
