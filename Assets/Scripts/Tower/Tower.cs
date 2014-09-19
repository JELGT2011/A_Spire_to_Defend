using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RAIN.Entities.Aspects;
using RAIN.Core;
using RAIN.Perception.Sensors;

public class Tower : MonoBehaviour
{
    public enum TYPE
    {
        basic,
        Dome_inator,
        Automated
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

    public TYPE _type;
    public TYPE Type
    {
        get { return _type; }
        set { _type = value; }
    }

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

    public float LastFired { get; set; }

    public bool IsAlive { get; set; }

    public GameObject PriorityTarget { get; set; }

    public Transform FiringMount { get; set; }

    public AIRig AIRig { get; set; }

    public VisualSensor VisualSensor { get; set; }

    public List<GameObject> _targets;

    /// <summary>
    /// Override the following when making sub towers, then call Initialize()
    /// 
    /// Tower.TYPE Type
    /// Transform FiringMount
    /// </summary>
    void Start()
    {
        switch (_type)
        {
            case TYPE.basic:
                FiringMount = GameObject.Find("DSLT_GUN").transform;
                break;
            case TYPE.Dome_inator:
                FiringMount = GameObject.Find("DSLT_GUN").transform;
                break;
            case TYPE.Automated:
                FiringMount = GameObject.Find("Root").transform;
                break;
            default:
                break;
        }

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

            Targets = VisualSensor.Matches;
            
            if (Targets.Count != 0)
            {
                AcquireTarget();
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
        switch (Behavior)
        {
            case BEHAVIOR.first:
                Targets.OrderBy(target => target.Entity.Form.GetComponentInChildren<Enemy>().NavMeshAgent.remainingDistance);
                break;

            case BEHAVIOR.last:
                Targets.OrderBy(target => target.Entity.Form.GetComponentInChildren<Enemy>().NavMeshAgent.remainingDistance);
                Targets.Reverse();
                break;

            case BEHAVIOR.strongest:
                Targets.OrderBy(target => target.Entity.Form.GetComponentInChildren<Enemy>().MaxHealth);
                break;

            case BEHAVIOR.weakest:
                Targets.OrderBy(target => target.Entity.Form.GetComponentInChildren<Enemy>().MaxHealth);
                Targets.Reverse();
                break;

            case BEHAVIOR.closest:
                Targets.OrderBy(target => Vector3.Distance(this.transform.position, target.Entity.Form.transform.position));
                break;

            default:
                Targets.OrderBy(target => target.Entity.Form.GetComponentInChildren<Enemy>().NavMeshAgent.remainingDistance);
                break;
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
        projectile.GetComponentInChildren<Projectile>().Target = Targets.ElementAt(0).Entity.Form.transform.root.gameObject;
    }
}