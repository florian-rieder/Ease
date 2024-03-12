using UnityEngine;

namespace Easing
{
	public class EaserColor : Easer<Color>
	{
		public override void Go()
		{
			if (By)
				Ease3.GoColorBy(this, Value.GetVector3(), Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
			else
				Ease3.GoColorTo(this, Value.GetVector3(), Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
		}
	}
}
