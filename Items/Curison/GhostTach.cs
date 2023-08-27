using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Items.Curison
{
    public class GhostTach : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 24;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.scale = 1f;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.knockBack = 4f;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.UseSound = SoundID.DD2_DarkMageAttack;
            Item.DamageType = DamageClass.Melee;
            Item.shootSpeed = 20;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height,
                DustID.BlueMoss, 0, 0, 100, Color.White, 1);

        }


        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextFloat() <= 0.4f)
            {
                target.AddBuff(BuffID.Confused, 300);
            }
        }

    }
}