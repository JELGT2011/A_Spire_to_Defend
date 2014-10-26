using UnityEngine;
using System.Collections;

namespace UINamespace
{
	/// <summary>
	/// Menus are screens to be on the screen either at the same time or on top of each other.
	/// They work like Activities in Android, kind of.
	/// </summary>
	public class UIMenu
	{
		private UIComponentGroupIterator m_componentGroupIterator;

		public UIMenu(UIComponentGroup headGroup)
		{
			m_componentGroupIterator = new UIComponentGroupIterator(headGroup);
		}

		public void OnGUI()
		{
			m_componentGroupIterator.OnGUI();
		}

		public void CalculateRenderingOutput()
		{
			m_componentGroupIterator.CalculateRenderingOutput();
		}

		public void CheckIfInputInButton(int x, int y)
		{
			m_componentGroupIterator.CheckIfInputInButton(x, y);
		}

		public void CheckIfInputInButton(float x, float y)
		{
			m_componentGroupIterator.CheckIfInputInButton(x, y);
		}

		public bool AcknowledgeInput(int x, int y)
		{
			return m_componentGroupIterator.AcknowledgeInput(x, y);
		}
		public bool AcknowledgeInput(float x, float y)
		{
			return m_componentGroupIterator.AcknowledgeInput(x, y);
		}
	}
}
