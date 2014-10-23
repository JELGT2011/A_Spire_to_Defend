using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridPoint : MonoBehaviour {
	public enum Trait{NON_BUILDABLE, IMPASSABLE};
	[SerializeField] private List<Trait> myTraits;

	public float speedMultiplier = 1.0f;

	private Tower tower;

	private Color oldColor;

	void Start(){
		if(myTraits==null){
			myTraits = new List<Trait>();
		}
	}

	//This method be called when an enemy arrives at a gridpoint, returns whether or not to replan afterwards based on the gridpoint being null or not
	public virtual GridPoint ArriveAtGridpoint(Enemy enemy){
		return null;
	}

	public virtual void Select(){
		oldColor = renderer.material.color;
		renderer.material.color = Color.Lerp (oldColor, Color.green, 0.5f);
	}

	public void Deselect(){
		renderer.material.color = oldColor;
	}

	public virtual bool CanBuild(){
		return myTraits != null && !myTraits.Contains (Trait.NON_BUILDABLE);
	}

	public virtual bool CanPassThough(){
		return myTraits != null && !myTraits.Contains (Trait.IMPASSABLE);
	}

	public bool HasTower(){
		return tower!=null;
	}

	public Tower GetTower(){
		return tower;
	}

	public virtual float GetSpeedMultiplier(){
		return speedMultiplier;
	}

	//Set up this GridPoint to be built on
	public virtual void CreateTower(Tower _tower){
		myTraits.Add (Trait.IMPASSABLE);

		tower = _tower;
	}

	//Remove the Building on this thing
	public virtual void DestroyTower(){

		Destroy (tower.gameObject);
		tower = null;
	}
}
