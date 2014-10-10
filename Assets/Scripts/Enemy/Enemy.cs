﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public enum TYPE
    {
        basic, advanced
    }

	public TYPE Type;

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

	public GridPoint Target;

	protected const float MIN_DIST = 0.1f;

	public SpriteRenderer healthRenderer;

	protected GridPoint[] path;
	protected int pathIndex=0;
	
    /// <summary>
    /// Initializes common values.  Do not override.
    /// </summary>
	public void Initialize(GridPoint start, GridPoint target)
    {
        Target = target;

        CurrentHealth = MaxHealth;
        CurrentSpeed = MaxSpeed;
        IsAlive = true;
        Accuracy = 1f;

		path = AStar.Path (start, target);

		foreach (GridPoint pnt in path) {
		}
    }

    /// <summary>
    /// Determines if it has reached the target.
    /// </summary>
    void Update(){
		EnemyUpdate ();


    }

	protected virtual void EnemyUpdate(){
		if(path!=null && path.Length>0){
			Vector3 differenceToGoal = (path[pathIndex].transform.position+Vector3.up) - transform.position;
			
			if (differenceToGoal.magnitude < MIN_DIST) {
				
				if(path.Length<=pathIndex+1){
					IsAlive =false;
					
					//TODO; hurt the player
				}
				else{
					pathIndex++;

					GridPoint grid = path[pathIndex].ArriveAtGridpoint(this);

					if(grid==null){

						if(Grid.Instance.GetGridPoint(path[pathIndex]).CanPassThough()){
							//Do nothing! We're good
						}
						else{
							path = AStar.Path(path[pathIndex-1],Target);
						}
					}
					else{
						path = AStar.Path(grid,Target);
					}
				}
				
			}
			else{
				transform.position+=differenceToGoal.normalized*CurrentSpeed*Time.deltaTime;
				
				//TODO; smooth look at
			}
		}
		
		
		if (!IsAlive){
			Global.Instance.RemoveEnemy(this);
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
        GameObject other;
        Projectile projectile;

        other = collision.collider.transform.root.gameObject;

        // Only check against projectiles
        if ((projectile = other.GetComponentInChildren<Projectile>()) != null)
        {
            CurrentHealth -= projectile.Damage;



            if (CurrentHealth <= 0)
            {
                IsAlive = false;
            }
			else{
				healthRenderer.color = Color.Lerp(Color.white,Color.red,((float)_maxHealth-(float)CurrentHealth)/(float)_maxHealth);
			}
        }
    }
}