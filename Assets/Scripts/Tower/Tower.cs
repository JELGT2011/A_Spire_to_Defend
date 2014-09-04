using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RAIN.Entities.Aspects;
using RAIN.Core;
using RAIN.Perception.Sensors;

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
            VisualSensor.Range = _range;
        }
    }

    public float _fireRate;
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    public IList<RAINAspect> Targets { get; set; }

    public SphereCollider RangeCollider { get; set; }

    public float LastFired { get; set; }

    public bool IsAlive { get; set; }

    public GameObject PriorityTarget { get; set; }

    public Transform FiringMount { get; set; }

    public AIRig AIRig { get; set; }

    public VisualSensor VisualSensor { get; set; }

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

        AIRig = GetComponentInChildren<RAIN.Core.AIRig>();
        VisualSensor = AIRig.AI.Senses.GetSensor("_visualSensor") as VisualSensor;

        Debug.LogWarning("set capacity more accurately");
        ProjectileManager.Init(10, ProjectileType);

        VisualSensor.Range = _range;
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

        Targets = VisualSensor.Matches;

        if (Targets.Count != 0)
        {
            switch (Behavior)
            {
                case BEHAVIOR.first:
                    // lambda functions to reorder targets based on the behavior
                    Targets.OrderBy(target => (target.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).NavMeshAgent.remainingDistance);
                    PriorityTarget = Targets.First<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.last:
                    Targets.OrderBy(target => (target.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).NavMeshAgent.remainingDistance);
                    PriorityTarget = Targets.Last<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.strongest:
                    Targets.OrderBy(target => (target.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.First<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.weakest:
                    Targets.OrderBy(target => (target.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.Last<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.closest:
                    // RAIN default behavior
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
}