using UnityEngine;
using System.Collections;

namespace UINamespace
{
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
}