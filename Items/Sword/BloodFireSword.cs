


using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SkyHell.Projectiles;
using System;
using SkyHell.Projectiles.StateMachine;

namespace SkyHell.Items.Sword
{
	public class BloodFireSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("Demon flame Twilight blade");
			Tooltip.SetDefault("The embodiment of omnipotence and power, its degree of fear is inevitable.\n\n"
			+ "A few words: Devil and God cannot coexist…");

			DisplayName.AddTranslation(7,"魔焰暮刃");
			Tooltip.AddTranslation(7,"全能与力量的化身，其令人恐惧的程度无可避免。\n\n只言片语：魔与神，本不能共存……");
		}
		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.damage =160;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.scale = 1.5f;
			Item.value = Item.sellPrice(0, 15, 0, 0);
			Item.rare = 6;
			Item.knockBack = 4f;
			Item.autoReuse = true;
			Item.crit = 15;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ModContent.ProjectileType<FireBallBeam>();
			Item.shootSpeed = 10;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//玩家的中心点坐标
			Vector2 playCenter = player.Center;
			//鼠标的中心点坐标
			Vector2 mousePos = Main.MouseWorld;

			//PM=OM-OP(单位向量)
			Vector2 vec = mousePos - playCenter;

            // 求出vec向量的角度，利用tan的反函数，注意，Math.Atan返回的是一个double类型
            // double比float类型的精准度高，所以需要强制转换
			//Anti-Tan A代表Anti 也就是反的意思
            float rad = (float)Math.Atan2(vec.Y, vec.X);
			for (float i = -MathHelper.Pi; i < MathHelper.Pi; i += MathHelper.PiOver2 / 16f)
			{
                //射击区域
                float readRed = rad + i * MathHelper.TwoPi;

                //最终运算结果
                Vector2 finalVec = new Vector2((float)Math.Cos(readRed),(float)Math.Sin(readRed));

                
                //单位向量乘以16就是16倍的速度
                finalVec *= 16;

                Projectile.NewProjectile(source, position, finalVec, type, damage, knockback, player.whoAmI, 0f);
            }

            return true;
		}

		//public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		//{
		//	if (Main.rand.Next(100) <= 10)
		//	{
		//		Item.shoot = ProjectileID.DD2PhoenixBowShot;
		//		return false;
		//	}

		//	else if (Main.rand.Next(100) >= 80)
		//	{
		//		Item.shoot = ProjectileID.NebulaArcanum;
		//		return false;
		//	}

		//	else if (Main.rand.Next(100) >= 0)
		//	{
		//		Item.shoot = ProjectileID.FairyQueenMagicItemShot;
		//		return true;
		//	}

		//	return true;

		//}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{

			target.AddBuff(BuffID.BrainOfConfusionBuff, 10);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height,
				DustID.GemTopaz, 0, 0, 100, Color.White, 1);

			Vector2 vector = new Vector2(2.0f, 5.0f);
			Vector2 vector1 = new Vector2(-5.0f,7.0f);
			Main.NewText(vector+vector1);
			//Main.NewText(vector - vector);
			//Main.NewText(vector*5.0f);

			Vector2 vector2 = new Vector2(2.0f, 1f);
			Main.NewText("最终结果:"+vector2*2);

            Vector2 OA = new Vector2(2, 3);
            Vector2 OB = new Vector2(-5, 2);

			Vector2 vector9 = Vector2.Normalize(OA + OB);
			Vector2 vector10 = vector9 * 16;

			Main.NewText(vector9);
            Main.NewText(vector10);
        }


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.Ectoplasm, 20);

			//四碎片
			recipe.AddIngredient(3456, 20);
			recipe.AddIngredient(3457, 15);
			recipe.AddIngredient(3458, 10);
			recipe.AddIngredient(3459, 5);

			//星云奥秘
			recipe.AddIngredient(3476, 1);

			//血腥屠刀/魔光剑 合成组
			recipe.AddRecipeGroup("EARecipes", 1);

			//喵刀
			recipe.AddIngredient(3063, 1);

			//任意三王魂
			recipe.AddRecipeGroup("SHKRecipes", 10);

			recipe.AddTile(TileID.LunarCraftingStation);

			recipe.Register();
		}
	}
}