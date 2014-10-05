using UnityEngine;
using System.Collections;

namespace UINamespace
{
	/// <summary>
	/// Grid Layout for placing buttons and things. Indexing is with integers so indexing is
	/// like normal array indexing. Top Left is [0,0] and bottom right [x-1,y-1].
	/// </summary>
	public class UIGridLayout : UIRelativeLayout
	{
		private ArrayList m_grid;
		
		private int m_xGridSections;
		private int m_yGridSections;

		public UIGridLayout(float xStart,
		                    float yStart,
		                    float xWidth,
		                    float yHeight,
		                    UIComponentGroup parentComponentGroup,
		                    int xGridSections,
		                    int yGridSections)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup)
		{
			m_xGridSections = xGridSections;
			m_yGridSections = yGridSections;

			m_grid = new ArrayList(xGridSections * yGridSections);
		}

		public UIGridLayout AddUIComponent(UIComponent component, int xSlot, int ySlot, int xSlotWidth, int ySlotWidth)
		{
			base.AddUIComponent(component);

			UIGridLayoutSlot gridSlot = new UIGridLayoutSlot(xSlot, ySlot, xSlotWidth, ySlotWidth, component);
			m_grid.Add(gridSlot);

			return this;
		}

		private class UIGridLayoutSlot
		{
			public int xSlotStart;
			public int ySlotStart;
			public int xSlotWidth;
			public int ySlotWidth;
			public UIComponent component;

			public UIGridLayoutSlot lowerSlot;
			public UIGridLayoutSlot aboveSlot;
			public UIGridLayoutSlot leftSlot;
			public UIGridLayoutSlot rightSlot;

			public UIGridLayoutSlot(int xSlotStart, int ySlotStart, int xSlotWidth, int ySlotWidth, UIComponent component)
			{
				this.xSlotStart = xSlotStart;
				this.ySlotStart = ySlotStart;
				this.xSlotWidth = xSlotWidth;
				this.ySlotWidth = ySlotWidth;
				this.component = component;
			}
		}

		public override void DrawGUI()
		{
			// do nothing
		}
	}
}
