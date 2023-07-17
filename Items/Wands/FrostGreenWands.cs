
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Localization;
using System;

namespace SkyHell.Items.Wands
{
	public class FrostGreenWands : ModItem
	{
		//public override void SetStaticDefaults()
		//{

			// DisplayName.SetDefault("Jungle leaf green staff");
			/* Tooltip.SetDefault("The jungle is growing restlessly, and the power of the sky has been desecrated…\n"
			+ "Launch three different barrages randomly…\n\n"
			+ " the peace of the past has disappeared, and disaster is gradually coming\n\n"
			+ "Magic missile: 90 damage\n\n"
			+ "Crazy star: 100 damage\n\n"
			+ "Rainbow Magic Missile: 120 damage"); */

			//DisplayName.AddTranslation(7,"丛林叶绿法杖");
			//Tooltip.AddTranslation(7,"丛林正在焦躁不安的生长，天空的力量已经被亵渎……\n\n昔日的和平已经消失，灾难正在逐步降临");
		//}

		public override void SetDefaults()
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Magic;
			Item.width = 27;
			Item.height = 27;
			Item.scale = 1f;
			Item.useTime = 40;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3f;
			Item.value = 360000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.shoot = 228;
            Item.shootSpeed = 12f;

            Item.crit = 5; // 基本暴击率加上游戏的+4基础率=8
			Item.mana = 10; // 魔法消耗
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 shoot = Main.MouseWorld - player.Center;
			float r = (float)Math.Atan2(shoot.Y, shoot.X);
			for (float i = -MathHelper.Pi; i < MathHelper.Pi; i += MathHelper.PiOver2 / 4f)
			{
					Vector2 plrToMouse = (r + i).ToRotationVector2() * 4f;
					if (Main.rand.Next(100) <= 76)
				{
					Projectile.NewProjectile(source, position, plrToMouse, type, damage, knockback, player.whoAmI, 0f);
				}
				else if (Main.rand.Next(100) <= 60)
				{
					Projectile.NewProjectile(source, position, plrToMouse, ProjectileID.RainbowRodBullet,damage, knockback, player.whoAmI, 0f);
				}
				else if (Main.rand.Next(100) >= 30)
				{
					Projectile.NewProjectile(source, position, plrToMouse, ProjectileID.MagicMissile, damage, knockback, player.whoAmI, 0f);
				}

		
			}

			
			return false;
		}
	

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, -5);
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.Ectoplasm, 20);

			recipe.AddIngredient(ItemID.ChlorophyteBar, 20);

			recipe.AddIngredient(ItemID.Pearlwood, 50);

			recipe.AddIngredient(ItemID.PixieDust, 35);

			recipe.AddIngredient(ItemID.RainbowRod, 1);

		    recipe.AddRecipeGroup("SHKRecipes", 30);

			recipe.AddRecipeGroup("PinkWandsRecipes", 1);

			recipe.AddTile(TileID.LihzahrdAltar);

			recipe.Register();
		}
	}
}