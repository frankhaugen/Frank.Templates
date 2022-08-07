using Microsoft.Xna.Framework;

namespace MonoGameTemplate;

public class Gravity
{
	private readonly List<IGravityPysics> _gravityPhysics;

	public Gravity(List<IGravityPysics> gravityPhysics)
	{
		_gravityPhysics = gravityPhysics;
	}

	public void Update(GameTime gameTime)
	{
		foreach (var gravityPhysics in _gravityPhysics)
		{
			gravityPhysics.Accelerate(new Vector2(0, 9.81f));
		}
	}
}