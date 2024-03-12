# Ease

Simple Unity Easing

The following easing functions are available for various animation effects:

```csharp
public enum EaseType
{
    Linear,
    SineIn, SineOut, SineInOut,
    QuadIn, QuadOut, QuadInOut,
    CubicIn, CubicOut, CubicInOut,
    QuartIn, QuartOut, QuartInOut,
    QuintIn, QuintOut, QuintInOut,
    ExpoIn, ExpoOut, ExpoInOut,
    CircIn, CircOut, CircInOut,
    BackIn, BackOut, BackInOut,
    ElasticIn, ElasticOut, ElasticInOut,
    BounceIn, BounceOut, BounceInOut,
    Spring
}
```

## Installation
Download this repository as a zip, and copy the `Assets/Ease` folder to your project's `Assets` folder.

## Example usage
```csharp
using UnityEngine;
using UnityEngine.UI;
using Easing;

public class TestEase : MonoBehaviour
{
	[SerializeField] private Image _slowStatus = null;
	private bool _slow;
	[SerializeField] private Image _pauseStatus = null;
	private bool _pause;
	[SerializeField] private Image _fastStatus = null;
	private bool _fast;
	private readonly Color _colorOff = Color.white.SetAlpha(.75f);
	private readonly Color _colorOn = Color.blue.SetAlpha(.75f);
	private readonly Vector3 _scaleTo = new Vector3(1.333f, 1.333f, 1f);
	private const float _time = .333f;
	private void Start()
	{
		_slowStatus.color = _colorOff;
		_pauseStatus.color = _colorOff;
		_fastStatus.color = _colorOff;
	}
	public void Slow()
	{
		_pause = false;
		_pauseStatus.color = _colorOff;
		_fast = false;
		_fastStatus.color = _colorOff;
		Time.timeScale = (_slow = !_slow) ? .1f : 1f;
		_slowStatus.StopAllCoroutines();
		Ease3.GoColorTo(_slowStatus, (_slow ? _colorOn : _colorOff).GetVector3(), _time, EaseType.SineInOut, 0f, 1, false, true);
		Ease3.GoScaleTo(_slowStatus, _scaleTo, _time, EaseType.BackInOut, 0f, 1, false, true, complete: () =>
		{
			Ease3.GoScaleTo(_slowStatus, Vector3.one, _time, EaseType.BackInOut, 0f, 1, false, true);
		});
	}
	public void Pause()
	{
		Time.timeScale = (_pause = !_pause) ? 0f : _slow ? .1f : _fast ? 2f : 1f;
		_pauseStatus.StopAllCoroutines();
		Ease3.GoColorTo(_pauseStatus, (_pause ? _colorOn : _colorOff).GetVector3(), _time, EaseType.SineInOut, 0f, 1, false, true);
		Ease3.GoScaleTo(_pauseStatus, _scaleTo, _time, EaseType.BackInOut, 0f, 1, false, true, complete: () =>
		{
			Ease3.GoScaleTo(_pauseStatus, Vector3.one, _time, EaseType.BackInOut, 0f, 1, false, true);
		});
	}
	public void Fast()
	{
		_slow = false;
		_slowStatus.color = _colorOff;
		_pause = false;
		_pauseStatus.color = _colorOff;
		Time.timeScale = (_fast = !_fast) ? 2f : 1f;
		_fastStatus.StopAllCoroutines();
		Ease3.GoColorTo(_fastStatus, (_fast ? _colorOn : _colorOff).GetVector3(), _time, EaseType.SineInOut, 0f, 1, false, true);
		Ease3.GoScaleTo(_fastStatus, _scaleTo, _time, EaseType.BackInOut, 0f, 1, false, true, complete: () =>
		{
			Ease3.GoScaleTo(_fastStatus, Vector3.one, _time, EaseType.BackInOut, 0f, 1, false, true);
		});
	}
}

```

More examples about usage of behaviours in the demo scene.

## Documentation
### Ease

The `Ease` class provides a collection of easing functions and utility methods for creating smooth animations in Unity. Ease either a float, or the alpha value of UI components.

#### Ease.Go
Initiates a coroutine-based animation to apply a custom `void update(float interpolatedValue)` function on a given game object.

```csharp
IEnumerator Go(MonoBehaviour m, float from, float to, float time,
    Action<float> update, EaseType type = EaseType.Linear, float delay = 0f,
    int repeat = 1, bool pingPong = false, bool realTime = false,
    Action complete = null)
```

#### Ease.GoAlpha
Initiates an alpha animation with specified parameters.

```csharp
IEnumerator GoAlpha(MonoBehaviour m, float from, float to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<float> update = null, Action complete = null)
```

#### Ease.GoAlphaTo
Initiates an alpha animation to the specified value.

```csharp
IEnumerator GoAlphaTo(MonoBehaviour m, float to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<float> update = null, Action complete = null)
```

#### Ease.GoAlphaBy
Initiates an alpha animation by the specified value.

```csharp
IEnumerator GoAlphaBy(MonoBehaviour m, float by, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<float> update = null, Action complete = null)
```

### Ease3
The `Ease3` class provides static methods for performing easing animations on Vector3 or transform

#### Ease3.Go
Starts an easing animation on a `Vector3` property from a starting value to an ending value to apply a custom `void update(float interpolatedValue)` function on a given game object.

```csharp
IEnumerator Go(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    Action<Vector3> update, EaseType type = EaseType.Linear, float delay = 0f,
    int repeat = 1, bool pingPong = false, bool realTime = false,
    Action complete = null)
```

#### Ease3.GoPosition
Starts an easing animation on the local position from a starting value to an ending value.

```csharp
IEnumerator GoPosition(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoPositionTo
Starts an easing animation on the local position of a Unity object to a specific value.

```csharp
IEnumerator GoPositionTo(MonoBehaviour m, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoPositionBy
Starts an easing animation on the local position of a Unity object by a specific value.
```csharp
IEnumerator GoPositionBy(MonoBehaviour m, Vector3 by, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoRotation
Starts an easing animation on the local rotation of a Unity object from a starting value to an ending value.

```csharp
IEnumerator GoRotation(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoRotationTo
Starts an easing animation on the local rotation of a Unity object to a specific value.
```csharp
IEnumerator GoRotationTo(MonoBehaviour m, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```
#### Ease3.GoRotationBy
Starts an easing animation on the local rotation of a Unity object by a specific value.

```csharp
IEnumerator GoRotationBy(MonoBehaviour m, Vector3 by, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoScale
Starts an easing animation on the local scale of a Unity object from a starting value to an ending value.

```csharp
IEnumerator GoScale(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoScaleTo
Starts an easing animation on the local scale of a Unity object to a specific value.

```csharp
IEnumerator GoScaleTo(MonoBehaviour m, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```
#### Ease3.GoScaleBy
Starts an easing animation on the local scale of a Unity object by a specific value.

```csharp
IEnumerator GoScaleBy(MonoBehaviour m, Vector3 by, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoColor
Starts an easing animation on the color of a Image component or the background color of the main camera from a starting value to an ending value.

```csharp
IEnumerator GoColor(MonoBehaviour m, Vector3 from, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoColorTo
Starts an easing animation on the color of a Image component or the background color of the main camera to a specific value.

```csharp
IEnumerator GoColorTo(MonoBehaviour m, Vector3 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

#### Ease3.GoColorBy
Starts an easing animation on the color of a Image component or the background color of the main camera by a specific value.

```csharp
IEnumerator GoColorBy(MonoBehaviour m, Vector3 by, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector3> update = null, Action complete = null)
```

### Ease4
The `Ease4` class provides static methods for performing easing animations on Vector4 properties, including color animations for Image components and camera backgrounds.

#### Ease4.Go
Starts an easing animation on a Vector4 property from a starting value to an ending value to apply a custom `void update(float interpolatedValue)` function on a given game object.

```csharp
IEnumerator Go(MonoBehaviour m, Vector4 from, Vector4 to, float time,
    Action<Vector4> update, EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1,
    bool pingPong = false, bool realTime = false, Action complete = null)
```

#### Ease4.GoColor
Starts an easing animation on the color of an Image component or the background color of the main camera.

```csharp
IEnumerator GoColor(MonoBehaviour m, Vector4 from, Vector4 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector4> update = null, Action complete = null)
```

#### Ease4.GoColorTo
Starts an easing animation on the color of an Image component or the background color of the main camera to a specific value.

```csharp
IEnumerator GoColorTo(MonoBehaviour m, Vector4 to, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector4> update = null, Action complete = null)
```
#### Ease4.GoColorBy
Starts an easing animation on the color of an Image component or the background color of the main camera by a specific value.

```csharp
IEnumerator GoColorBy(MonoBehaviour m, Vector4 by, float time,
    EaseType type = EaseType.Linear, float delay = 0f, int repeat = 1, bool pingPong = false, bool realTime = false,
    Action<Vector4> update = null, Action complete = null, )
```

### Extension methods
Vectors are used as parameters for the above methods instead of Color objects. To help with converting between Colors and Vectors, extension methods are made available: `Vector3.GetColor()`, `Vector4.GetColor()`, `Color.GetVector3()`, `Color.GetVector4()`, `Color.SetAlpha(float alpha)`.

### Easing functions

Easing functions provide a convenient way to interpolate values smoothly over time. These functions define how the intermediate values between a start and an end point are calculated based on a time factor.

Easing functions are provided as static methods in the `Ease` and `Ease3` classes. To use an easing function, simply call the corresponding method and provide the `start`, `end` and `time` parameters:

```csharp
using Easing;

// Interpolating a scalar
float startValue = 0.0f;
float endValue = 1.0f;
float time = 0.5f; // Progress of the interpolation, usually between 0 and 1

float interpolatedValue = Ease.QuadInOut(startValue, endValue, time);

Debug.Log(interpolatedValue); // Output: 0.5

// Interpolating a vector
Vector3 startVector = Vector3.zero;
Vector3 endVector = Vector3.one;
float time = 0.5f

Vector3 interpolatedVector = Ease3.QuintInOut(startVector, endVector, time);

Debug.Log(interpolatedVector); // Output: Vector3(0.5, 0.5, 0.5)
```