using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConveyorBeltGridPoint : GridPoint {
	public ConveyorBeltGridPoint next;

	public override GridPoint ArriveAtGridpoint (Enemy enemy)
	{
		List<GridPoint> gridPointList = new List<GridPoint>();
		if(enemy != null)
		{
			ConveyorBeltGridPoint current = this;

			while(current != null)
			{
				gridPointList.Add(current);
				current = current.next;
			}

			if(gridPointList.Count > 0)
			{
				//Make the enemy move along the path of conveyorbelt nodes
				enemy.SetPath(gridPointList.ToArray());
			}
		}
		return null;
	}

}
