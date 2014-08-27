using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public enum TYPE
    {
        basic
    }

    protected TYPE _type;
    public TYPE Type
    {
        get { return _type; }
        set { _type = value; }
    }

    protected int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    protected int _currentHealth;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    protected float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    protected bool _isAlive;
    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    protected bool _targetReached;
    public bool TargetReached
    {
        get { return _targetReached; }
        set { _targetReached = value; }
    }

    protected NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent
    {
        get { return _navMeshAgent; }
        set { _navMeshAgent = value; }
    }

    protected float _distance;
    public float Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }

    protected Vector3 _target;
    public Vector3 Target
    {
        get { return _target; }
        set { _target = value; }
    }

    /// <summary>
    /// Common code for all Enemy objects to function.
    /// Calls Initialize which should be overriden.
    /// </summary>
    void Start()
    {
        _isAlive = true;

        // find and navigate to target
        _target = GameObject.Find("Finish").GetComponent<Transform>().position;
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(_target);

        Initialize();
    }

    /// <summary>
    /// Function to override when making sub enemies.
    /// Enemy.TYPE _type
    /// int _maxHealth
    /// int _currentHealth
    /// float _speed
    /// </summary>
    void Initialize()
    {
        _type = TYPE.basic;
        _maxHealth = 1;
        _currentHealth = 1;
        _speed = 3f;
        Finish();
    }

    /// <summary>
    /// Called at the end of Initialize().
    /// </summary>
    void Finish()
    {
        _navMeshAgent.speed = _speed;
    }

    /// <summary>
    /// Determines if it has reached the target.
    /// </summary>
    void Update()
    {
        // check if enemy is close enough to Target
        if (Mathf.Abs(_navMeshAgent.remainingDistance) == 0)
        {
            _isAlive = false;
            _targetReached = true;
        }

        if (!_isAlive)
        {
            Destroy(gameObject);
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
        Projectile projectile;

        collisionObject = collision.collider.gameObject;

        // Only check against projectiles
        if ((projectile = collisionObject.GetComponent<Projectile>()) != null)
        {
            _currentHealth -= projectile.Damage;

            if (_currentHealth <= 0)
            {
                _isAlive = false;
            }
        }
    }
}