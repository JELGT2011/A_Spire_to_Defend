using UnityEngine;
using System.Collections.Generic;

namespace UINamespace
{
	public abstract class UIComponent
	{
		private int m_componentId;

		protected UIAnchor m_anchor;
		protected float m_xStart;
		protected float m_yStart;
		protected float m_xWidth;
		protected float m_yHeight;

		protected UIComponentGroup m_parentComponentGroup = null;

			// Amount of screen space for this component to work with
		protected UIComponentRenderingInput m_parentRenderingInput = null;

			// Amount of screen space for child components to work with
		protected UIComponentRenderingInput m_childRenderingInput = null;

		public int Id
		{
			get { return m_componentId; }
		}

		protected UIComponent(float xStart,
		                      float yStart,
		                      float xWidth,
		                      float yHeight,
		                      UIComponentGroup parentComponentGroup,
		                      UIAnchorLocation anchorLocation)
		{
			m_componentId = UI.GenerateId();

			m_xStart = xStart;
			m_yStart = yStart;
			m_xWidth = xWidth;
			m_yHeight = yHeight;

			m_parentComponentGroup = parentComponentGroup;

			m_anchor = new UIAnchor(anchorLocation);
		}

		public float GetStartX() { return m_xStart; }
		public float GetWidthX() { return m_xWidth; }
		public float GetStartY() { return m_yStart; }
		public float GetHeightY() { return m_yHeight; }

		public abstract void DrawGUI();
		public abstract LinkedList<UIComponent> GetChildComponentsList();
		public abstract void CalculateRenderingOutput(); //Create a UIComponentRenderingInput class/struct to pass to child components

		public UIComponentRenderingInput GetChildComponentRenderingInput()
		{
			if (null == m_childRenderingInput)
				CalculateRenderingOutput();
			return m_childRenderingInput;
		}

		public sealed class UIComponentRenderingInput
		{
			public float xStart;
			public float yStart;
			public float xWidth;
			public float yHeight;
			public UIAnchorLocation anchorLocation;
			public UILayoutType layoutType;
			public UIComponentRenderingInput(float xStart, float yStart, float xWidth, float yHeight, UIAnchorLocation anchorLocation, UILayoutType layoutType)
			{
				this.xStart = xStart;
				this.yStart = yStart;
				this.xWidth = xWidth;
				this.yHeight = yHeight;
				this.anchorLocation = anchorLocation;
				this.layoutType = layoutType;
			}
		}
	}
}
