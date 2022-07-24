
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;


namespace SkyHell.UIX
{
	public class SkyHellUI : ModMenu
	{
		private const string menuAssetPath = "SkyHell/UIX"; // Creates a constant variable representing the texture path, so we don't have to write it out multiple times

		//主界面上面的Logo
		public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"{menuAssetPath}/Menu");
		//public override Asset<Texture2D> Logo => Mod
		//白天的过度场景
		//public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/ExampleSun");

		//夜晚的过度场景
		//public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/ExampliumMoon");

		//切换场景后播放的音乐
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Music/Menu");

		//public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<ExampleSurfaceBackgroundStyle>();

		public override string DisplayName => "SkyHell-Menu";

		//花里胡哨的彩色颜色动态变换）
		/*
		public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor) {
			drawColor = Main.DiscoColor; // Changes the draw color of the logo
			return true;
		}
		*/
	}
		
	}


