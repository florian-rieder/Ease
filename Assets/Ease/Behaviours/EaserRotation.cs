using UnityEngine;
namespace ca.HenrySoftware.Rage
{
	public class EaserRotation : Easer<Vector3>
	{
		public override void Go()
		{
			if (By)
				Ease3.GoRotationBy(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
			else
				Ease3.GoRotationTo(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
		}
	}
}
