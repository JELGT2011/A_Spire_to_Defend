using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RAIN.Core;
using RAIN.Perception.Sensors;
using RAIN.Entities.Aspects;

public class Tower : MonoBehaviour
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



    public GameObject Projectile;

    protected TYPE _type;
    public TYPE Type
    {
        get { return _type; }
        set { _type = value; }
    }

    protected BEHAVIOR _behavior;
    public BEHAVIOR Behavior
    {
        get { return _behavior; }
        set { _behavior = value; }
    }

    protected int _damage;
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    protected float _fireRate;
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    protected float _lastFired;
    public float LastFired
    {
        get { return _lastFired; }
        set { _lastFired = value; }
    }

    protected float _range;
    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }

    protected bool _isAlive;
    public bool IsAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    protected AIRig _aiRig;
    public AIRig AIRig
    {
        get { return _aiRig; }
        set { _aiRig = value; }
    }

    protected IList<RAINAspect> _targets;
    public IList<RAINAspect> Targets
    {
        get { return _targets; }
        set { _targets = value; }
    }

    protected Enemy _priorityTarget;
    public Enemy PriorityTarget
    {
        get { return _priorityTarget; }
        set { _priorityTarget = value; }
    }

    protected VisualSensor _visualSensor;
    public VisualSensor VisualSensor
    {
        get { return _visualSensor; }
        set { _visualSensor = value; }
    }

    /// <summary>
    /// Override the following when making sub towers, then call Initialize()
    /// 
    /// Tower.TYPE _type
    /// BEHAVIOR _behavior
    /// float _fireRate (do not set to 0)
    /// float _range
    /// </summary>
    void Start()
    {
        _type = TYPE.basic;
        _behavior = BEHAVIOR.first;
        _fireRate = 1f;
        _range = 10f;

        Initialize();
    }

    /// <summary>
    /// Initializes functions based on inputed start values.
    /// Do not override.
    /// </summary>
    void Initialize()
    {
        _isAlive = true;
        _lastFired = 0;
        _targets = new List<RAINAspect>();

        _aiRig = gameObject.GetComponentInChildren<AIRig>();
        _visualSensor = (VisualSensor)_aiRig.AI.Senses.GetSensor("_visualSensor");
        _visualSensor.Range = _range;
    }

    void Update()
    {
        if (!_isAlive)
        {
            Destroy(gameObject);
        }
        else if ((Time.time - _lastFired) >= (1 / _fireRate))
        {
            AcquireTarget();

            if (_targets.Count != 0)
            {
                Fire();
            }
        }
        else
        {
            _lastFired -= Time.deltaTime;
        }
    }

    void AcquireTarget()
    {
        // get all targets in range of tower from _visualSensor
        _targets = _visualSensor.Matches;

        if (_targets.Count != 0)
        {
            switch (_behavior)
            {
                case BEHAVIOR.first:
                    // lambda functions to reorder _targets based on the behavior
                    _targets.OrderBy(aspect => aspect.Entity.Form.GetComponent<Enemy>().Distance);
                    _priorityTarget = _targets.First<RAINAspect>().Entity.Form.GetComponent<Enemy>();
                    break;

                case BEHAVIOR.last:
                    _targets.OrderBy(aspect => aspect.Entity.Form.GetComponent<Enemy>().Distance);
                    _priorityTarget = _targets.Last<RAINAspect>().Entity.Form.GetComponent<Enemy>();
                    break;

                case BEHAVIOR.strongest:
                    _targets.OrderBy(aspect => aspect.Entity.Form.GetComponent<Enemy>().MaxHealth);
                    _priorityTarget = _targets.First<RAINAspect>().Entity.Form.GetComponent<Enemy>();
                    break;

                case BEHAVIOR.weakest:
                    _targets.OrderBy(aspect => aspect.Entity.Form.GetComponent<Enemy>().MaxHealth);
                    _priorityTarget = _targets.Last<RAINAspect>().Entity.Form.GetComponent<Enemy>();
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
        _lastFired = Time.time;

        // create projectile from Projectile prefab attached
        GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;

        // set its target
        projectile.GetComponent<Projectile>().Target = _priorityTarget.transform;
    }
}