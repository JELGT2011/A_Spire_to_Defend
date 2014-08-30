using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RAIN.Core;
using RAIN.Perception.Sensors;
using RAIN.Entities.Aspects;

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
        set { _range = value; }
    }

    public float _fireRate;
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    public float LastFired { get; set; }

    public bool IsAlive { get; set; }

    public AIRig AIRig { get; set; }

    public IList<RAINAspect> Targets { get; set; }

    public GameObject PriorityTarget { get; set; }

    public VisualSensor VisualSensor { get; set; }

    public Transform FiringMount { get; set; }

    /// <summary>
    /// Override the following when making sub towers, then call Initialize()
    /// 
    /// Tower.TYPE _type
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
        Targets = new List<RAINAspect>();

        AIRig = gameObject.GetComponentInChildren<AIRig>();
        VisualSensor = (VisualSensor)AIRig.AI.Senses.GetSensor("_visualSensor");
        VisualSensor.Range = _range;
    }

    void Update()
    {
        if (!IsAlive)
        {
            Destroy(transform.root.gameObject);
        }
        else if ((Time.time - LastFired) >= (1 / _fireRate))
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
        // get all targets in range of tower from _visualSensor
        Targets = VisualSensor.Matches;

        if (Targets.Count != 0)
        {
            switch (_behavior)
            {
                case BEHAVIOR.first:
                    // lambda functions to reorder _targets based on the behavior
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).NavMeshAgent.remainingDistance);
                    PriorityTarget = Targets.First<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.last:
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).NavMeshAgent.remainingDistance);
                    PriorityTarget = Targets.Last<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.strongest:
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.First<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.weakest:
                    Targets.OrderBy(aspect => (aspect.Entity.Form.GetComponentInChildren(typeof(IEnemy)) as IEnemy).MaxHealth);
                    PriorityTarget = Targets.Last<RAINAspect>().Entity.Form;
                    break;

                case BEHAVIOR.closest:
                    // RAIN does this by default
                    break;

                default:
                    // will target the closest enemy
                    break;
            }
        }
    }

    /// <summary>
    /// Fires a projectile and prevents refiring for time = (1 / _fireRate).
    /// </summary>
    void Fire()
    {
        // set cooldown
        LastFired = Time.time;

        // create projectile from Projectile prefab attached
        GameObject projectile = Instantiate(_projectileType, FiringMount.position, FiringMount.rotation) as GameObject;

        // set its target
        (projectile.GetComponentInChildren(typeof(IProjectile)) as IProjectile).Target = PriorityTarget;
    }
}