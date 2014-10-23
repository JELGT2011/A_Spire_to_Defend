using UnityEngine;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UINamespace
{
	public class UIStaticButton : UIButton
	{
		private UIComponent m_idleComponent = null;
		private UIComponent m_highlightedComponent = null;

		private UIButtonHitBox m_hitBox;

		public UIStaticButton(float xStart,
		                float yStart,
		                float xWidth,
		                float yHeight,
		                UIComponentGroup parentComponentGroup,
		                UILayoutType layoutType,
		                UIAnchorLocation anchorLocation,
		                IUIButtonListener buttonListener)
			: base(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation, buttonListener)
		{
			m_componentType = UIComponentType.BUTTON;
			m_hitBox = new UIButtonHitBox(xStart, yStart, xWidth, yHeight, this, layoutType, anchorLocation);
		}

		public override void SetStartStateIdle()
		{
			m_highlightedComponent.Enabled = false;
			m_idleComponent.Enabled = true;
		}

		public new UIStaticButton AddUIComponent(UIComponent component)
		{
			base.AddUIComponent(component);
			
			return this;
		}

		public override void SetChildrenEnabled(bool enabled)
		{
			switch (m_idleComponent.GetComponentType())
			{
			case UIComponentType.RENDERABLE:
				m_idleComponent.Enabled = enabled;
				break;
			case UIComponentType.BUTTON:
				(m_idleComponent as UIButton).SetChildrenEnabled(enabled);
				break;
			case UIComponentType.LAYOUT:
				(m_idleComponent as UIComponentGroup).SetChildrenEnabled(enabled);
				break;
			}

			switch (m_highlightedComponent.GetComponentType())
			{
			case UIComponentType.RENDERABLE:
				m_highlightedComponent.Enabled = enabled;
				break;
			case UIComponentType.BUTTON:
				(m_highlightedComponent as UIButton).SetChildrenEnabled(enabled);
				break;
			case UIComponentType.LAYOUT:
				(m_highlightedComponent as UIComponentGroup).SetChildrenEnabled(enabled);
				break;
			}
		}

		public UIStaticButton SetUIComponentIdle(UIComponent component)
		{
			AddUIComponent(component);

			m_idleComponent = component;
			component.SetParentComponentGroup(this);

			return this;
		}

		public UIStaticButton SetUIComponentHighlighted(UIComponent component)
		{
			AddUIComponent(component);

			m_highlightedComponent = component;
			component.SetParentComponentGroup(this);

			return this;
		}

		public override void CalculateRenderingOutput()
		{
			base.CalculateRenderingOutput();

			m_hitBox.CalculateRenderingOutput();
		}

		public override void OnMouseEnter()
		{

		}
		public override void OnMouseExit()
		{
		}
		public override void OnMouseClick()
		{
		}
		public override void OnHighlighted()
		{
		}
		public override void OnIdle()
		{
		}
		public override void OnSelected()
		{
		}

		private bool previousFrame = false;
		public override bool CheckIfInputInButton(float x, float y)
		{
			bool inButton = m_hitBox.CheckIfInputInButton(x, y);

			if (previousFrame == inButton)
				return inButton;
			else
				PerformInButtonChangeAction(inButton);
			return previousFrame = inButton;
		}
		public override bool CheckIfInputInButton(int x, int y)
		{
			bool inButton = m_hitBox.CheckIfInputInButton(x, y);
			
			if (previousFrame == inButton)
				return inButton;
			else
				PerformInButtonChangeAction(inButton);
			return previousFrame = inButton;
		}
		private void PerformInButtonChangeAction(bool inButton)
		{
			if (true == inButton)
			{
				m_highlightedComponent.Enabled = true;
				m_idleComponent.Enabled = false;

				m_buttonListener.OnHighlighted();
			}
			else if (false == inButton)
			{
				m_highlightedComponent.Enabled = false;
				m_idleComponent.Enabled = true;

				m_buttonListener.OnIdle();
			}
		}

		public override bool AcknowledgeInput(float x, float y)
		{
			if (m_hitBox.CheckIfInputInButton(x, y))
			{
				m_buttonListener.OnSelected();
				return true;
			}
			else
				return false;
		}
		public override bool AcknowledgeInput(int x, int y)
		{
			if (m_hitBox.CheckIfInputInButton(x, y))
			{
				m_buttonListener.OnSelected();
				return true;
			}
			else
				return false;
		}
	}
}

