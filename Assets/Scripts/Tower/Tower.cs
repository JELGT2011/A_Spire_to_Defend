using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tower : MonoBehaviour, ITower
{
    public enum TYPE
    {
        basic
    }

    public enum BEHAVIOR
    {
        first,
        last,
        strongest,
        weakest,
        closest
    };

    public GameObject _projectileType;
    public GameObject ProjectileType
    {
        get { return _projectileType; }
        set { _projectileType = value; }
    }

    public int Cost { get; set; }

    public float Created { get; set; }

    public ProjectileManager ProjectileManager { get; set; }

    public TYPE Type { get; set; }

    public BEHAVIOR _behavior;
    public BEHAVIOR Behavior
    {
        get { return _behavior; }
        set { _behavior = value; }
    }

    public int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float _range;
    public float Range
    {
        get { return _range; }
        set 
        {
            _range = value;
            RangeCollider.radius = _range;
        }
    }

    public float _fireRate;
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    public List<GameObject> Targets { get; set; }

    public SphereCollider RangeCollider { get; set; }

    public float LastFired { get; set; }

    public bool IsAlive { get; set; }

    public GameObject PriorityTarget { get; set; }

    public Transform FiringMount { get; set; }

    /// <summary>
    /// Override the following when making sub towers, then call Initialize()
    /// 
    /// Tower.TYPE Type
    /// </summary>
    void Start()
    {
        Type = TYPE.basic;
        FiringMount = GameObject.Find("DSLT_GUN").transform;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    public void Initialize()
    {
        IsAlive = true;
        LastFired = 0;
        
        Created = Time.realtimeSinceStartup;

        ProjectileManager = ScriptableObject.CreateInstance<ProjectileManager>();

        Debug.LogWarning("set capacity more accurately");
        ProjectileManager.Init(10, ProjectileType);

        RangeCollider = transform.root.gameObject.GetComponentInChildren<SphereCollider>();
        RangeCollider.radius = Range;

        Targets = new List<GameObject>();

        
    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
        else if ((Time.time - LastFired) >= (1 / FireRate))
        {
            AcquireTarget();

            if (Targets.Count != 0)
            {
                Fire();
            }
        }
        else
        {
            LastFired -= Time.deltaTime;
        }
    }

    void AcquireTarget()
    {

        if (Targets.Count != 0)
        {
            switch (Behavior)
            {
                case BEHAVIOR.first:
                    // lambda functions to reorder targets based on the behavior
                    Targets.OrderBy(target => (target.GetComponentInChildren(typeof(IEnemy)) as IEnemy).NavMeshAgent.remainingDistance);
                    PriorityTarget = Targets.First<GameObject>();
                    break;

                case BEHAVIOR.last:
                    Targets.OrderBy(target => (target.GetComponentInChildren(typeof(IEnemy)) as IEnemy).NavMeshAgent.remainingDistance);
                    PriorityTarget = Targets.Last<GameObject>();
                    break;

                case BEHAVIOR.strongest:
                    Targets.OrderBy(target => (target.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.First<GameObject>();
                    break;

                case BEHAVIOR.weakest:
                    Targets.OrderBy(target => (target.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.Last<GameObject>();
                    break;

                case BEHAVIOR.closest:
                    Targets.OrderBy(target => Vector3.Distance(target.transform.position, gameObject.transform.position));
                    PriorityTarget = Targets.First<GameObject>();
                    break;

                default:
                    // undefined targeting behavior
                    break;
            }
        }
    }

    /// <summary>
    /// Fires a projectile and prevents refiring for time = (1 / FireRate).
    /// </summary>
    void Fire()
    {
        // set cooldown
        LastFired = Time.time;

        // create projectile from Projectile prefab attached
        GameObject projectile = Instantiate(ProjectileType, FiringMount.position, FiringMount.rotation) as GameObject;

        // set its target
        (projectile.GetComponentInChildren(typeof(IProjectile)) as IProjectile).Target = PriorityTarget;
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject enemy = collider.transform.root.gameObject;

        if (enemy.tag == "Enemy")
        {
            Targets.Add(enemy);
        }
    }
}