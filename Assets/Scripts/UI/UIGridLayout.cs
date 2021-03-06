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
		public int XGridSections
		{
			get { return m_xGridSections; }
		}
		public int YGridSections
		{
			get { return m_yGridSections; }
		}

		public UIGridLayout(string componentName,
		                    float xStart,
		                    float yStart,
		                    float xWidth,
		                    float yHeight,
		                    UIComponentGroup parentComponentGroup,
		                    UIAnchorLocation anchorLocation,
		                    int xGridSections,
		                    int yGridSections)
			: base(componentName, xStart, yStart, xWidth, yHeight, parentComponentGroup, anchorLocation)
		{
			m_xGridSections = xGridSections;
			m_yGridSections = yGridSections;

			m_grid = new ArrayList(xGridSections * yGridSections);
		}
		public UIGridLayout(float xStart,
		                    float yStart,
		                    float xWidth,
		                    float yHeight,
		                    UIComponentGroup parentComponentGroup,
		                    UIAnchorLocation anchorLocation,
		                    int xGridSections,
		                    int yGridSections)
			: this("", xStart, yStart, xWidth, yHeight, parentComponentGroup, anchorLocation, xGridSections, yGridSections)
		{
			SetName(Id.ToString());
		}

		public UIGridLayout AddUIComponent(UIComponent component, int xSlot, int ySlot, int xSlotWidth, int ySlotHeight)
		{
//			float xGridSlotStart = 1f / m_xGridSections * xSlot;
//			float yGridSlotStart = 1f / m_yGridSections * (m_yGridSections - ySlot - 1);
//			float xGridSlotWidth = 1f / m_xGridSections * xSlotWidth;
//			float yGridSlotHeight = 1f / m_yGridSections * ySlotHeight;
//			UIRelativeLayout gridSlotLayout = new UIRelativeLayout(xGridSlotStart, yGridSlotStart, xGridSlotWidth, yGridSlotHeight, this, UIAnchorLocation.LEFT_BOT);

			float xGridSlotStart = 1f / m_xGridSections * xSlot;
			float yGridSlotStart = 1f / m_yGridSections * (m_yGridSections - ySlot);
			float xGridSlotWidth = 1f / (float)m_xGridSections * xSlotWidth;
			float yGridSlotHeight = 1f / (float)m_yGridSections * ySlotHeight;
			UIRelativeLayout gridSlotLayout = new UIRelativeLayout(xGridSlotStart, yGridSlotStart, xGridSlotWidth, yGridSlotHeight, this, UIAnchorLocation.LEFT_TOP);

			gridSlotLayout.AddUIComponent(component);

			base.AddUIComponent(gridSlotLayout);

			UIGridLayoutSlot gridSlot = new UIGridLayoutSlot(xSlot, ySlot, xSlotWidth, ySlotHeight);
			m_grid.Add(gridSlot);

			return this;
		}

			// Always has an anchor at the Top-Left corner. It is
			// indexed like reading left to right and top to bottom.
		private class UIGridLayoutSlot
		{
			public int xSlotStart;
			public int ySlotStart;
			public int xSlotWidth;
			public int ySlotHeight;

			public UIGridLayoutSlot lowerSlot;
			public UIGridLayoutSlot aboveSlot;
			public UIGridLayoutSlot leftSlot;
			public UIGridLayoutSlot rightSlot;
			
			public UIGridLayoutSlot(int xSlotStart, int ySlotStart, int xSlotWidth, int ySlotHeight)
			{
				this.xSlotStart = xSlotStart;
				this.ySlotStart = ySlotStart;
				this.xSlotWidth = xSlotWidth;
				this.ySlotHeight = ySlotHeight;
			}
		}
	}
}
