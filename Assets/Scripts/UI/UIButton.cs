using UnityEngine;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UINamespace
{
	public abstract class UIButton : UIComponentGroup
	{
		protected IUIButtonListener m_buttonListener;

		public UIButton(string componentName,
		                float xStart,
		                float yStart,
		                float xWidth,
		                float yHeight,
		                UIComponentGroup parentComponentGroup,
		                UILayoutType layoutType,
		                UIAnchorLocation anchorLocation,
		                IUIButtonListener buttonListener)
			: base(componentName, xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation)
		{
			m_componentType = UIComponentType.BUTTON;
			if (null == buttonListener)
				m_buttonListener = new UIButtonListenerDoNothing();
			else
				m_buttonListener = buttonListener;
		}

		public override void CalculateRenderingOutput()
		{
			if (null == m_parentComponentGroup)
				m_parentRenderingInput = new UIComponentRenderingInput(0f, 0f, 1f, 1f, UILayoutType.RELATIVE_LAYOUT);
			
			if (null == m_parentRenderingInput)
				m_parentRenderingInput = m_parentComponentGroup.GetChildComponentRenderingInput();
			
			m_childRenderingInput = new UIComponentRenderingInput(m_parentRenderingInput.xBottomLeft,
			                                                      m_parentRenderingInput.yBottomLeft,
			                                                      m_parentRenderingInput.xTopRight,
			                                                      m_parentRenderingInput.yTopRight,
			                                                      m_parentRenderingInput.layoutType);
		}

		public new UIButton AddUIComponent(UIComponent component)
		{
			base.AddUIComponent(component);
			
			return this;
		}

		public void AddButtonListener(IUIButtonListener buttonListener)
		{
			m_buttonListener = buttonListener;
		}
		
		public abstract void OnMouseEnter();
		public abstract void OnMouseExit();
		public abstract void OnMouseClick();
		public abstract void OnHighlighted();
		public abstract void OnIdle();
		public abstract void OnSelected();

		public abstract bool CheckIfInputInButton(float x, float y);
		public abstract bool CheckIfInputInButton(int x, int y);
		public abstract bool AcknowledgeInput(float x, float y);
		public abstract bool AcknowledgeInput(int x, int y);

		public abstract void SetStartStateIdle();
	}

	public class UIButtonListenerDoNothing : IUIButtonListener
	{
		public void OnHighlighted()
		{
			// do nothing
		}

		public void OnIdle()
		{
			// do nothing
		}

		public void OnSelected()
		{
			// do nothing
		}
	}
}

