using Microsoft.Xna.Framework;

namespace MonoGameTemplate.Pysics;

public interface IGravityPysics
{
	void Accelerate(Vector2 acceleration);
}