using UnityEngine;
namespace ca.HenrySoftware.Rage
{
	public class EaserPosition : Easer<Vector3>
	{
		public override void Go()
		{
			if (By)
				Ease3.GoPositionBy(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
			else
				Ease3.GoPositionTo(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
		}
	}
}
