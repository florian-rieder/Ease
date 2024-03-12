namespace Easing
{
	public class EaserAlpha : Easer<float>
	{
		public override void Go()
		{
			if (By)
				Ease.GoAlphaBy(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
			else
				Ease.GoAlphaTo(this, Value, Time, Type, Delay, Repeat, PingPong, RealTime, complete: Complete.Invoke);
		}
	}
}
