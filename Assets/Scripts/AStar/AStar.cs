using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar {
	private static int maxChecksPerFrame=1000;//In case of error states

	public static GridPoint[] Path(GridPoint start, GridPoint goal){
		List<PathingNode> closedSet = new List<PathingNode> ();
		List<PathingNode> openSet = new List<PathingNode> ();
		
		PathingNode currNode = new PathingNode (start);
		openSet.Add (currNode);
		
		int count = 0;
		while (openSet.Count!=0 && count<maxChecksPerFrame) {
			count++;
			currNode=openSet[0];
			
			foreach(PathingNode node in openSet){
				if(node.GetFScore(goal)<currNode.GetFScore(goal)){
					currNode = node;
				}
			}
			if(currNode.loc.transform.position==goal.transform.position){
				return GetPathFromNode(currNode);
			}
			else{

				openSet.Remove(currNode);
				closedSet.Add(currNode);
				
				List<GridPoint> moves = GetPossibleNextPointsFromPosition(currNode.loc);
				
				foreach(GridPoint move in moves){
					PathingNode potentialNode = new PathingNode(move,currNode);
					
					if(closedSet.Contains(potentialNode)){
					}
					else if(openSet.Contains(potentialNode)){
						int index = openSet.IndexOf(potentialNode);
						if(openSet[index].g_score > potentialNode.g_score){
							openSet[index]=potentialNode;
						}
					}
					else{
						openSet.Add(potentialNode);
					}
				}
			}
			
		}
		return null;
	}

	private static GridPoint[] GetPathFromNode(PathingNode goal){
		List<GridPoint> protoPath = new List<GridPoint>();

		if (goal.GetParent () == null) {
			//Debug.Log ("Hit the if; "+goal.loc.transform.position);
			protoPath.Add (goal.loc);
			goal = goal.GetParent();	
		}
		else{
			//Debug.Log ("Hit the else");
			while (goal.GetParent()!=null) {
				//Debug.Log ("Hit the while: "+goal.loc.transform.position);
				protoPath.Add (goal.loc);
				goal = goal.GetParent();
			}
		}
		
		protoPath.Reverse ();
		
		return protoPath.ToArray ();
		
	}

	private static List<GridPoint> GetPossibleNextPointsFromPosition(GridPoint current){
		List<GridPoint> nextMoves = new List<GridPoint>();
		
		//Left
		GridPoint left = Grid.Instance.GetGridPoint(current.transform.position.x-1,current.transform.position.z);
		if (left != null && left.CanPassThough()) {
			nextMoves.Add(left);	
		}
		
		//Right
		GridPoint right = Grid.Instance.GetGridPoint(current.transform.position.x+1,current.transform.position.z);
		if (right != null && right.CanPassThough()) {
			nextMoves.Add(right);	
		}

		//Forward
		GridPoint fore = Grid.Instance.GetGridPoint(current.transform.position.x,current.transform.position.z+1);
		if (fore != null && fore.CanPassThough()) {
			nextMoves.Add(fore);	
		}
		
		//Back
		GridPoint back = Grid.Instance.GetGridPoint(current.transform.position.x,current.transform.position.z-1);
		if (back != null && back.CanPassThough()) {
			nextMoves.Add(back);	
		}
		

		return nextMoves;
	}
}
