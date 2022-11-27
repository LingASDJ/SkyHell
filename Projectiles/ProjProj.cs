using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkyHell.Projectiles.StateMachine;
using Terraria;
using Terraria.GameContent;

namespace SkyHell.Projectiles
{
    public class ProjProj : SMProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("回力标");
        }
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.1f;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.scale = 1.25f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 4;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Projectile.type].Value;
            Main.spriteBatch.Draw(tex,
                Projectile.Center - Main.screenPosition, tex.Frame(),
                Color.White, Projectile.rotation,
                tex.Size() * 0.5f,
                Projectile.scale, SpriteEffects.None, 0f);
            // 返回false阻止原版的绘制
            return false;
        }


        private class ForwardState : ProjState
        {
            public override void AI(SMProjectile proj)
            {
                var projectile = proj.Projectile;
                projectile.rotation += 0.05f * projectile.velocity.Length();
                proj.Timer++;
                float factor = proj.Timer / 90f;
                factor *= factor;
                projectile.velocity = Vector2.Normalize(projectile.velocity) * 9f * (1.0f - factor);
                if (proj.Timer >= 90)
                {
                    proj.SetState<ChaseState>();
                }
            }
        }



        private class ChaseState : ProjState
        {
            public override void AI(SMProjectile proj)
            {
                var projectile = proj.Projectile;
                proj.Timer++;
                projectile.rotation += 0.05f * projectile.velocity.Length();
                var target = ProjUtils.FindNearestEnemy(projectile.Center, 1000, npc => npc.value > 1 || npc.damage > 1);
                if (target != null)
                {
                    var unit = Vector2.Normalize(target.Center - projectile.Center);
                    projectile.velocity = (projectile.velocity * 15f + unit * 10f) / 16f;
                }
                if (proj.Timer >= 300)
                {
                    proj.SetState<BackwardState>();
                }
            }
        }


        private class BackwardState : ProjState
        {
            public override void AI(SMProjectile proj)
            {
                var projectile = proj.Projectile;
                projectile.rotation -= 0.05f * projectile.velocity.Length();
                Player owner = Main.player[projectile.owner];
                projectile.velocity = Vector2.Normalize(owner.Center - projectile.Center) * 9f;
                if (projectile.Hitbox.Intersects(owner.Hitbox))
                {
                    projectile.Kill();
                }
            }
        }

        public override void AIBefore()
        {

        }

        public override void Initialize()
        {
            RegisterState(new ForwardState());
            RegisterState(new ChaseState());
            RegisterState(new BackwardState());
        }
    }
}
