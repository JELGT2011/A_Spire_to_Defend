using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;

namespace UINamespace
{
	public enum UILayoutType
	{
		RELATIVE_LAYOUT,
		PIXEL_LAYOUT
	};

	public enum UIComponentType
	{
		RENDERABLE,
		BUTTON,
		LAYOUT
	};

	public abstract class UIComponent
	{
		private int m_componentId;
		protected UIComponentType m_componentType;

			// This determines how much screen room this component will use of the amount give.
			// If there is no parent or the parent is the entire screen (i.e. 0f, 0f, 1f, 1f), then
			// these values will determine how much of the screen this component uses. If the parent
			// only uses like half of it, then these values will treat the parent as the screen and
			// will scale according to the parent, so will be smaller, but these values won't change.
		protected UIAnchor m_anchor;

		protected UILayoutType m_layoutType;

		protected UIComponentGroup m_parentComponentGroup = null;
		public void SetParentComponentGroup(UIComponentGroup newParent)
		{
			m_parentComponentGroup = newParent;
		}

			// Amount of screen space for this component to work with
		protected UIComponentRenderingInput m_parentRenderingInput = null;

			// Amount of screen space for child components to work with
		protected UIComponentRenderingInput m_childRenderingInput = null;



		public int Id
		{
			get { return m_componentId; }
		}

		public UIComponentType GetComponentType()
		{
			return m_componentType;
		}

		protected UIComponent(float xStart,
		                      float yStart,
		                      float xWidth,
		                      float yHeight,
		                      UIComponentGroup parentComponentGroup,
		                      UILayoutType layoutType,
		                      UIAnchorLocation anchorLocation)
		{
			m_componentId = UI.GenerateId();

			m_anchor = new UIAnchor(anchorLocation, xStart, yStart, xWidth, yHeight);
			m_layoutType = layoutType;
			m_parentComponentGroup = parentComponentGroup;
		}

		public abstract LinkedList<UIComponent> GetChildComponentsList();
		public abstract bool HasChildComponents();
		public abstract void CalculateRenderingOutput(); //Create a UIComponentRenderingInput class/struct to pass to child components

		public UIComponentRenderingInput GetChildComponentRenderingInput()
		{
			if (null == m_childRenderingInput)
				CalculateRenderingOutput();
			return m_childRenderingInput;
		}

		public sealed class UIComponentRenderingInput
		{
			public float xBottomLeft;
			public float yBottomLeft;
			public float xTopRight;
			public float yTopRight;
			public UILayoutType layoutType;
			public UIComponentRenderingInput(float xBottomLeft, float yBottomLeft, float xTopRight, float yTopRight, UILayoutType layoutType)
			{
				this.xBottomLeft = xBottomLeft;
				this.yBottomLeft = yBottomLeft;
				this.xTopRight = xTopRight;
				this.yTopRight = yTopRight;
				this.layoutType = layoutType;
			}
			public float GetWidth()
			{
				return xTopRight - xBottomLeft;
			}
			public float GetHeight()
			{
				return yTopRight - yBottomLeft;
			}
		}

		public sealed class UIPixelRenderingInfo
		{
			public Rect rect;
			public ArrayList extraData;
			public UIPixelRenderingInfo()
			{
				extraData = new ArrayList();
			}
		}
	}
}
