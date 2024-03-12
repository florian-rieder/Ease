using UnityEngine;
namespace ca.HenrySoftware.Rage
{
	public class EaserScale : Easer<Vector3>
	{
		public override void Go()
		{
			if (By)
				Ease3.GoScaleTo(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
			else
				Ease3.GoScaleBy(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
		}
	}
}
