using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float radius;
    public float speed;
    Transform enemyTransform;
    Rigidbody2D rb;
    public int vida = 100;
    int index;
    [HideInInspector] public bool found;
    public Transform[] waypoints;
    public Transform player;
    private enum StateMachine
    {
        Attack,
        Follow,
        Idle,
    }
    private StateMachine stateMachine;
    private void Start()
    {
        if (rb == null)
        {
            rb = this.GetComponent<Rigidbody2D>();
        }
        stateMachine = StateMachine.Idle;
    }
    private void Update()
    {
        switch (stateMachine)
        {
            case StateMachine.Idle:
                if (Vector2.Distance(transform.position,player.position) <= radius * 2f)
                {
                    stateMachine = StateMachine.Follow;
                    found = !found;
                }
                Idle();
                break;
            case StateMachine.Follow:
                if (Vector2.Distance(transform.position,player.position) > radius * 2f)
                {
                    stateMachine = StateMachine.Idle;
                    found = !found;
                }
                Follow();
                break;
            case StateMachine.Attack:
                Attack();
                break;
        }
    }
    public virtual void Attack()
    {
        //Verifica se o inimigo está perto do jogador, se estiver ele executa um ataque
        Debug.Log("Inimigo ataca");
    }
    public virtual void Follow()
    {
        //Verifica se o inimigo não está perto do jogador
        if (found)
        {
            Move(player);
        }
        Debug.Log("Inimigo seguindo " + player.name);
    }
    private void OnDrawGizmosSelected()
    {
        if (enemyTransform == null)
        {
            enemyTransform = transform;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyTransform.position, radius);
    }
    
    public virtual void Idle()
    {
        //Metodo utilizado enquanto o inimigo ñ tem visão do jogador
        
        if (!found)
        {
            if (Vector2.Distance(transform.position, waypoints[index].position) <= radius)
            {
                index++;
            }
            if (index > waypoints.Length - 1)
            {
                index = 0;
            }
            Move(waypoints[index]);
        }
        Debug.Log("Movimentação padrão, movendo para o waypoint " + index);
    }

    public virtual void Die()
    {
        //Verifica a vida atual do inimigo, se for menor ou igual a 0, ele morre
        Debug.Log("Inimigo morre");
    }
    
    public virtual void Move(Transform destiny)
    {
        Vector2 target = new Vector2(destiny.position.x,rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
