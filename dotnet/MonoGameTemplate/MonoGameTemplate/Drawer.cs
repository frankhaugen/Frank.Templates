using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Shapes;
using MonoGameTemplate.Models.Configuration;

namespace MonoGameTemplate;

public class Drawer : IDrawer
{
	private readonly IOptions<GameState> _gameState;
	
	public Drawer(IOptions<GameState> gameState)
	{
		_gameState = gameState;
	}

	public void Begin()
	{							  
		_gameState.Value.SpriteBatch.Begin();
	}

	public void End()
	{
		_gameState.Value.SpriteBatch.End();
	}

	public void DrawCircl(Vector2 center, float radius, int sides, Color color)
	{
		_gameState.Value.SpriteBatch.DrawCircle(center, radius, sides, color);
	}

	public void DrawPolygon(Vector2 center, Polygon polygon, Color color)
	{
		_gameState.Value.SpriteBatch.DrawPolygon(center, polygon, color);
	}

	public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
	{
		_gameState.Value.SpriteBatch.DrawString(spriteFont, text, position, color);
		//_gameState.Value.SpriteBatch.DrawString(spriteFont, _gameState.Value.GameTime.ElapsedGameTime.ToString(), position, color);
	}

	public void DrawLine(Vector2 origin, IEnumerable<Vector2> vertices, Color color)
	{
		var previousEnd = origin;
		foreach (var vertex in vertices)
		{
			_gameState.Value.SpriteBatch.DrawLine(previousEnd, vertex, color);
		}
	}

	public void DrawLines(Vector2 start, Vector2 end, Color color)
	{
		_gameState.Value.SpriteBatch.DrawLine(start, end, color);
	}
}