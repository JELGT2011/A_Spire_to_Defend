using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public abstract class UIComponent
	{
		private int m_componentId;
		protected UIAnchor m_anchor;

		public int Id
		{
			get { return m_componentId; }
		}

		protected UIComponent()
		{
			m_componentId = UI.GenerateId();
		}

		public abstract void DrawGUI();

	}
}
