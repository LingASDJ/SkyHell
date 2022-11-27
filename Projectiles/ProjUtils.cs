using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace SkyHell.Projectiles
{
    public static class ProjUtils
    {
        public static NPC FindNearestEnemy(Vector2 pos, float maxDis, Func<NPC, bool> cond = null)
        {
            NPC target = null;
            foreach (var npc in Main.npc)
            {
                if (npc.active && !npc.friendly && cond(npc))
                {
                    float dis = Vector2.Distance(pos, npc.Center);
                    if (dis < maxDis)
                    {
                        maxDis = dis;
                        target = npc;
                    }
                }
            }
            return target;
        }
    }
}
