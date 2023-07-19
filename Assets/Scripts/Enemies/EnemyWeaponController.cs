using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyWeaponController : MonoBehaviour
{
    [SerializeField] private EnemyController m_Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (m_Enemy.canAttack)
        {
            if (other.CompareTag("Player"))
            {
                print("Atacou: " + other.name);
                m_Enemy.canAttack = false;
                other.gameObject.GetComponent<PlayerHealthController>().ReceiveDamage(m_Enemy.damagePower);
                m_Enemy.agent.isStopped = false;
                
                m_Enemy.trackPlayer();
            }
        }
    }
}
