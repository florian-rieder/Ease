using UnityEngine;
namespace ca.HenrySoftware.Rage
{
	public class EaserColorAlpha : Easer<Color>
	{
		public override void Go()
		{
			if (By)
				Ease4.GoColorBy(this, Value.GetVector4(), Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
			else
				Ease4.GoColorTo(this, Value.GetVector4(), Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
		}
	}
}
