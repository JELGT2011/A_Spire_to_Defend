﻿using UnityEngine;
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

	public void Select(){
		oldColor = renderer.material.color;
		renderer.material.color = Color.Lerp (oldColor, Color.green, 0.5f);
	}

	public void Deselect(){
		renderer.material.color = oldColor;
	}

	public bool CanBuild(){
		return myTraits != null && !myTraits.Contains (Trait.NON_BUILDABLE) ;
	}

	public bool CanPassThough(){
		return myTraits != null && !myTraits.Contains (Trait.IMPASSABLE);
	}

	public bool HasTower(){
		return tower!=null;
	}

	public float GetSpeedMultiplier(){
		return speedMultiplier;
	}

	//Set up this GridPoint to be built on
	public void CreateTower(Tower _tower){
		myTraits.Add (Trait.IMPASSABLE);
		myTraits.Add (Trait.NON_BUILDABLE);

		tower = _tower;
	}

	//Remove the Building on this thing
	public void DestroyTower(){
		myTraits.Remove (Trait.NON_BUILDABLE);

		Destroy (tower);
		tower = null;
	}
}
