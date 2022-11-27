
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
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("Jungle leaf green staff");
			Tooltip.SetDefault("The jungle is growing restlessly, and the power of the sky has been desecrated…\n"
			+ "Launch three different barrages randomly…\n\n"
			+ "A word: the peace of the past has disappeared, and disaster is gradually coming\n\n"
			+ "Magic missile: 90 damage\n\n"
			+ "Crazy star: 100 damage\n\n"
			+ "Rainbow Magic Missile: 120 damage");

			DisplayName.AddTranslation(7,"丛林叶绿法杖");
			Tooltip.AddTranslation(7,"丛林正在焦躁不安的生长，天空的力量已经被亵渎……\n\n只言片语：昔日的和平已经消失，灾难正在逐步降临");
		}

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Magic;
			Item.width = 27;
			Item.height = 27;
			Item.scale = 1f;
			Item.useTime = 20;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15f;
			Item.value = 360000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.StarWrath;
			Item.shootSpeed = 25;

			Item.crit = 1; // 基本暴击率加上游戏的+4基础率=8
			Item.mana = 30; // 魔法消耗
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 shoot = Main.MouseWorld - player.Center;
			float r = (float)Math.Atan2(shoot.Y, shoot.X);
			// 这时候偏移量就需要是[-pi/2, pi/2]了，然后我们发射40个
			for (float i = -MathHelper.PiOver2; i < MathHelper.PiOver2; i += MathHelper.PiOver2 / 4f)
			{
					Vector2 plrToMouse = (r + i).ToRotationVector2() * 4f;
					if (Main.rand.Next(100) <= 10)
				{
					Projectile.NewProjectile(source, position, plrToMouse, type, damage, knockback, player.whoAmI, 0f);
				}
				else if (Main.rand.Next(100) <= 20)
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
		
			


            //Vector2 target = Main.MouseWorld - player.Center;
            //float ceilingLimit = target.Y;
            //if (ceilingLimit > player.Center.Y - 20f)
            //{
            //	ceilingLimit = player.Center.Y - 20f;
            //}
            //// Loop these functions 3 times.
            //for (int i = 0; i < 5; i++)
            //{
            //	position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
            //	position.Y -= 100 * i;
            //	

            //	if (heading.Y < 0f)
            //	{
            //		heading.Y *= -1f;
            //	}

            //	if (heading.Y < 10f)
            //	{
            //		heading.Y = 10f;

            //	}

            

            //}

		public override Vector2? HoldoutOffset()
		{
			// X坐标往里移动10像素，Y坐标向上移动5像素
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