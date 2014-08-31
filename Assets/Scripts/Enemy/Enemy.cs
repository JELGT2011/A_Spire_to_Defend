using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IEnemy
{
    public enum TYPE
    {
        basic
    }

    public TYPE Type { get; set; }

    public int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int CurrentHealth { get; set; }

    public float _maxSpeed;
    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }

    public float CurrentSpeed { get; set; }

    public float Accuracy { get; set; }

    public bool IsAlive { get; set; }

    public bool TargetReached { get; set; }

    public NavMeshAgent NavMeshAgent { get; set; }

    public Animator Animator { get; set; }

    public Vector3 Target { get; set; }

    /// <summary>
    /// Override the following when making sub enemies, then call Initialize()
    /// 
    /// Enemy.TYPE Type
    /// </summary>
    void Start()
    {
        Type = TYPE.basic;

        Initialize();
    }

    /// <summary>
    /// Initializes common values.  Do not override.
    /// </summary>
    void Initialize()
    {
        CurrentHealth = MaxHealth;
        CurrentSpeed = MaxSpeed;

        IsAlive = true;
        Accuracy = 1f;

        // find and navigate to target
        Target = GameObject.Find("Finish").GetComponent<Transform>().position;

        NavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        NavMeshAgent.SetDestination(Target);
        NavMeshAgent.speed = CurrentSpeed;

        // find animator
        Animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Determines if it has reached the target.
    /// </summary>
    void Update()
    {
        // check if enemy is close enough to Target
        if (Mathf.Abs(NavMeshAgent.remainingDistance) <= Accuracy)
        {
            IsAlive = false;
            TargetReached = true;
            GameObject.FindGameObjectWithTag("Global").GetComponent<Global>().Lives -= CurrentHealth;
        }

        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }

        Animator.SetFloat("CurrentSpeed", CurrentSpeed);
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