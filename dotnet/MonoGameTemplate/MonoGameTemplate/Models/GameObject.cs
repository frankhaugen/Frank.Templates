using Frank.Libraries.Calculators.FluentCalculation;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Shapes;
using MonoGameTemplate.Extensions;

namespace MonoGameTemplate.Models;

public interface ITransform
{
	Vector2 Position { get; set; }
	Quaternion Direction { get; set; }
}

public interface IRigidbody
{
	Vector2 Velocity { get; set; }
	public float Mass { get; set; }
}

public class Transform : ITransform
{
	public Vector2 Position { get; set; }
	public Quaternion Direction { get; set; }
}

public class GameObject : ITransform, IRigidbody
{
	public GameObject(Polygon polygon)
	{
		Polygon = polygon;
	}

	public Vector2 Position { get; set; }
	public Quaternion Direction { get; set; }

	public Vector2 Velocity { get; set; }
	public float Mass { get; set; }

	public Polygon Polygon { get; }

	public Color Color { get; set; }
	public float Radius { get; set; }
	public float Friction { get; set; }
	public float Restitution { get; set; }
	public float Density { get; set; }
	public float Inertia { get; set; }
	public float AngularVelocity { get; set; }
	public float Torque { get; set; }
	public float AngularAcceleration { get; set; }
	public float InertiaTensor { get; set; }

	public Drawable GetDrawable()
	{
		return new Drawable(Position, Polygon, Color);
	}
}

public static class PolygonFactory
{
	public static Polygon GetSquare(float width, float height) => new Rectangle(Vector2.Zero.X.ToInt(), Vector2.Zero.Y.ToInt(), width.ToInt(), height.ToInt()).GetPolygon();
	public static Polygon GetCircle(float radius, int sides) => CreateCircle(radius, sides).ToPolygon();


	private static Vector2[] CreateCircle(double radius, int sides)
	{
		Vector2[] circle = new Vector2[sides];
		double num1 = 2.0 * Math.PI / (double)sides;
		double num2 = 0.0;
		for (int index = 0; index < sides; ++index)
		{
			circle[index] = new Vector2((float)(radius * Math.Cos(num2)), (float)(radius * Math.Sin(num2)));
			num2 += num1;
		}

		return circle;
	}

	private static Vector2[] CreateEllipse(float rx, float ry, int sides)
	{
		Vector2[] ellipse = new Vector2[sides];
		double num1 = 0.0;
		double num2 = 2.0 * Math.PI / (double)sides;
		int index = 0;
		while (index < sides)
		{
			float x = rx * (float)Math.Cos(num1);
			float y = ry * (float)Math.Sin(num1);
			ellipse[index] = new Vector2(x, y);
			++index;
			num1 += num2;
		}

		return ellipse;
	}
}

public record Drawable(Vector2 center, Polygon polygon, Color color);