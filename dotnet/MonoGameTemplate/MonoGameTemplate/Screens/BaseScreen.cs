using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

namespace MonoGameTemplate.Screens
{
	internal class BaseScreen : GameScreen
	{
		public BaseScreen(IGameWindow game) : base(game.Game)
		{
		}

		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}

		public override void Draw(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}