using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordController : MonoBehaviour
{
    [SerializeField] private PlayerCombatController m_Player;

    private void OnTriggerEnter(Collider other)
    {
        // print("Atacou: " + other.name);
        if (m_Player.canAttack)
        {
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyController>().TakeDamage(m_Player.attackDamage);
                m_Player.animator.SetBool("canAttack", false);
                m_Player.canAttack = false;
            }
        }
    }
}
