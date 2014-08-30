using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IEnemy
{
    public enum TYPE
    {
        basic
    }

    public TYPE Type;

    public int MaxHealth;

    public int CurrentHealth;

    public float MaxSpeed;

    public float CurrentSpeed;

    public bool IsAlive;

    public bool TargetReached;

    public NavMeshAgent _navMeshAgent;

    public float Accuracy;

    public float Distance;

    public Vector3 Target;

    /// <summary>
    /// Override the following when making sub enemies, then call Initialize()
    /// 
    /// Enemy.TYPE _type
    /// int _maxHealth
    /// int _currentHealth
    /// float _speed
    /// </summary>
    void Start()
    {
        Type = TYPE.basic;
        MaxHealth = 10;
        CurrentHealth = 10;
        CurrentSpeed = 4f;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    void Initialize()
    {
        IsAlive = true;
        Accuracy = 1f;

        // find and navigate to target
        Target = GameObject.Find("Finish").GetComponent<Transform>().position;

        _navMeshAgent = transform.parent.gameObject.GetComponentInChildren<NavMeshAgent>();
        _navMeshAgent.SetDestination(Target);
        _navMeshAgent.speed = CurrentSpeed;
    }

    /// <summary>
    /// Determines if it has reached the target.
    /// </summary>
    void Update()
    {
        // check if enemy is close enough to Target
        if (Mathf.Abs(_navMeshAgent.remainingDistance) <= Accuracy)
        {
            IsAlive = false;
            TargetReached = true;
            GameObject.FindGameObjectWithTag("Global").GetComponent<Global>().Lives -= CurrentHealth;
        }

        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
    }

    /// <summary>
    /// Only processes collisions with a GameObject that has a Projectile component.
    /// Calculates damage done to the target, and destroys if needed.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject;
        IProjectile projectile;

        collisionObject = collision.collider.transform.root.gameObject;

        // Only check against projectiles
        if ((projectile = (collisionObject.GetComponentInChildren(typeof(IProjectile))) as IProjectile) != null)
        {
            CurrentHealth -= projectile.Damage;

            if (CurrentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }
}