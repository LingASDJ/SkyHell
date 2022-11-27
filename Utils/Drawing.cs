using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace SkyHell.Utils
{
    public static class Drawing
    {
        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, int step, float scale, Color c = default(Color))
        {
            Vector2 unit = Vector2.Normalize(end - start);
            float r = unit.ToRotation();
            float dis = (end - start).Length();
            for (int i = 0; i < dis; i += step)
            {
                sb.Draw(TextureAssets.MagicPixel.Value, start + unit * i,
                    new Rectangle(0, 0, 1, 1), c, r, new Vector2(0.5f, 0.5f), scale, SpriteEffects.None, 0f);
            }
        }
    }
}
