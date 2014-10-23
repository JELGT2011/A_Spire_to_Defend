using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConveyorBeltGridPoint : GridPoint {

	private Color _oldColor;

	//We will change enemy's direction to up, down, or right depending on the type of tile
	public enum Direction {Right, Up, Down};
	public Direction newDirection;
	
	public float newSpeed = 0.1f;

	public ConveyorBeltGridPoint next;

	public List<GridPoint> gridPointList;
	
	public override GridPoint ArriveAtGridpoint (Enemy enemy)
	{
		gridPointList = new List<GridPoint>();
		if(enemy != null)
		{
			ConveyorBeltGridPoint current = this;

			while(current.next != null)
			{
				gridPointList.Add(next);
				current = current.next;
			}

			if(gridPointList.Count > 0)
			{
				//Make the enemy move along the path of conveyorbelt nodes
				enemy.setPath(gridPointList.ToArray());
			}
		}
		return this;
	}

	//Returns the new direction which the enemy should be rotated to
	public Direction getDirection()
	{
		return newDirection;
	}
}
