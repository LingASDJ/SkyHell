using System;
using Microsoft.Xna.Framework;
using SkyHell.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Projectiles
{
    public class YinYangTower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("阴 阳 怪 塔");
        }
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = -2;
            Projectile.friendly = true;
            Projectile.light = 0.1f;
            Projectile.timeLeft = 400;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            Projectile.alpha = 255;
            Projectile.extraUpdates = 0;
        }

        public int Timer1
        {
            get
            {
                return (int)Projectile.ai[0];
            }
            set
            {
                Projectile.ai[0] = value;
            }
        }

        public int Timer2
        {
            get
            {
                return (int)Projectile.ai[1];
            }
            set
            {
                Projectile.ai[1] = value;
            }
        }
        public override void AI()
        {
            Main.dayTime = false;
            Main.time = 0;
            Projectile.velocity *= 0f;
            for (float r = 12.14f; r > 0; r -= MathHelper.TwoPi / 10f)
            {
                float r2 = (float)Math.Atan2(Projectile.ai[0], 94f)* 94f;

                for (int i = -1; i <= 1; i += 2)
                {
                    Vector2 pos = Projectile.Center +
                        new Vector2((float)Math.Cos(r + r2), (float)Math.Sin(r + r2)) * r * 20f * i;
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height
                    , i < 0 ? MyDustId.IceTorch : MyDustId.PinkBubble, 0f, 0f, 100, default, 1.5f);
                    dust.noGravity = true;
                    dust.velocity *= 0;
                    dust.position = pos;
                }
            }
            Timer1++;
            float factor = Math.Min(1.0f, Timer1 / 300f);
            if (factor < 0.2f)
            {
                return;
            }

            Timer2++;
            int shootCD = (int)(10 + (1 - factor) * 20);
            if (Timer2 >= shootCD)
            {
                float maxDis = 1000f;
                NPC target = null;
                // 选取最近npc，如果target是null说明没有临近的敌人
                foreach (var npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.value > 0 && !npc.dontTakeDamage)
                    {
                        float dis = Vector2.Distance(npc.Center, Projectile.Center);
                        if (dis < maxDis)
                        {
                            maxDis = dis;
                            target = npc;
                        }
                    }
                }
                if (target != null)
                {
                    Projectile.ai[1] = 0;

                    Projectile.NewProjectile(null, Projectile.Center, Vector2.Normalize(target.Center - Projectile.Center) * 19f, ProjectileID.MagicMissile, 100, 5f, Projectile.owner, 0, Main.rand.Next(2));
                }
            }
        }
    }
}
