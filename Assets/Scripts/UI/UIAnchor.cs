using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public enum UIAnchorLocation
	{
		LEFT_TOP,
		LEFT_MID,
		LEFT_BOT,
		MID_TOP,
		MID_MID,
		MID_BOT,
		RIGHT_TOP,
		RIGHT_MID,
		RIGHT_BOT
	};

	public class UIAnchor
	{
		private UIAnchorLocation m_anchorLocation;

		private delegate int pixelDelegate(int value);
		private delegate float relativeDelegate(float value);

		public UIAnchor(UIAnchorLocation anchorLocation)
		{

		}
	}
}
