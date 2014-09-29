using UnityEngine;
using System.Collections;

public class PathingNode {
	public GridPoint loc;
	public int g_score=0;
	private PathingNode _parent;

	private const float SPEED_IMPACT=2;

	public PathingNode(GridPoint _loc){
		this.loc = _loc;
	}

	public PathingNode(GridPoint _loc, PathingNode parent): this(_loc){
		_parent = parent;
		g_score = parent.g_score + 1;
	}

	public int GetFScore(GridPoint goal){
		return (int)(g_score + (goal.transform.position-loc.transform.position).sqrMagnitude -loc.speedMultiplier*SPEED_IMPACT);
	}

	public PathingNode GetParent(){
		return _parent;
	}

	public override bool Equals (object obj){
		PathingNode objNode = (PathingNode)obj;

		return obj != null && objNode != null && loc.Equals(objNode.loc);
	}

	public override int GetHashCode ()
	{
		return base.GetHashCode ();
	}

}
