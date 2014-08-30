using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IEnemy
{
    public enum TYPE
    {
        basic
    }

    public TYPE _type;
    public TYPE Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int _currentHealth;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float _maxSpeed;
    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }

    public float _currentSpeed;
    public float CurrentSpeed
    {
        get { return _currentSpeed; }
        set { _currentSpeed = value; }
    }

    public bool _isAlive;
    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    public bool _targetReached;
    public bool TargetReached
    {
        get { return _targetReached; }
        set { _targetReached = value; }
    }

    public NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent
    {
        get { return _navMeshAgent; }
        set { _navMeshAgent = value; }
    }

    public float _accuracy;
    public float Accuracy
    {
        get { return _accuracy; }
        set { _accuracy = value; }
    }

    public float _distance;
    public float Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }

    public Vector3 _target;
    public Vector3 Target
    {
        get { return _target; }
        set { _target = value; }
    }

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
        _type = TYPE.basic;
        _maxHealth = 10;
        _currentHealth = 10;
        _currentSpeed = 4f;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    void Initialize()
    {
        _isAlive = true;
        _accuracy = 1f;

        // find and navigate to target
        _target = GameObject.Find("Finish").GetComponent<Transform>().position;

        _navMeshAgent = transform.parent.gameObject.GetComponentInChildren<NavMeshAgent>();
        _navMeshAgent.SetDestination(_target);
        _navMeshAgent.speed = _currentSpeed;
    }

    /// <summary>
    /// Determines if it has reached the target.
    /// </summary>
    void Update()
    {
        // check if enemy is close enough to Target
        if (Mathf.Abs(_navMeshAgent.remainingDistance) <= _accuracy)
        {
            _isAlive = false;
            _targetReached = true;
            GameObject.FindGameObjectWithTag("Global").GetComponent<Global>().Lives -= _currentHealth;
        }

        if (!_isAlive)
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
            _currentHealth -= projectile.Damage;

            if (_currentHealth <= 0)
            {
                _isAlive = false;
            }
        }
    }
}