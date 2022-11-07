using Microsoft.Xna.Framework;
using MonoGameTemplate.Pysics;

namespace MonoGameTemplate;

public class GameObject : IGravityPysics
{
	public void Accelerate(Vector2 acceleration)
	{
		throw new NotImplementedException();
	}

	public Vector2 Position { get; set; }
	public Vector2 Velocity { get; set; }
	public Vector2 Acceleration { get; set; }
	public float Mass { get; set; }
	public float Radius { get; set; }
	public float Friction { get; set; }
	public float Restitution { get; set; }
	public float Density { get; set; }
	public float Inertia { get; set; }
	public float AngularVelocity { get; set; }
	public float Torque { get; set; }
	public float AngularAcceleration { get; set; }
	public float InertiaTensor { get; set; }
}