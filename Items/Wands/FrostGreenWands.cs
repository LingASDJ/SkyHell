
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


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
			Tooltip.AddTranslation(7,"丛林正在焦躁不安的生长，天空的力量已经被亵渎……\n随机发射三种不同的弹幕……\n\n只言片语：昔日的和平已经消失，灾难正在逐步降临\n\n魔法导弹:90伤害\n\n狂星:100伤害\n\n彩虹魔法导弹:120伤害");
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
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
			Item.shootSpeed = 16;


			Item.crit = 20; // 基本暴击率加上游戏的+4基础率=8
			Item.mana = 10; // 魔法消耗
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 20f)
			{
				ceilingLimit = player.Center.Y - 20f;
			}
			// Loop these functions 3 times.
			for (int i = 0; i < 5; i++)
			{
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}

				if (heading.Y < 10f)
				{
					heading.Y = 10f;
					
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.2f;

				if (Main.rand.Next(100) <= 10) { 
					Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
				} else if (Main.rand.Next(100) <= 20) 
				{
					Projectile.NewProjectile(source, position, heading, ProjectileID.RainbowRodBullet, damage=120, knockback, player.whoAmI, 0f, ceilingLimit);
				} else if (Main.rand.Next(100) >= 30)
				{
					Projectile.NewProjectile(source, position, heading, ProjectileID.MagicMissile, damage=90, knockback, player.whoAmI, 0f, ceilingLimit);
				}

			}

			return false;
		}

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