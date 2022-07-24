
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


namespace SkyHell.Items.Wands
{
	public class PinkCrystalSkyWands : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("等待翻译");
			Tooltip.SetDefault("等待翻译");

			DisplayName.AddTranslation(7,"紫晶天空法杖");
			Tooltip.AddTranslation(7, "紫晶的魔矿力与恶地的魔矿和陨石的综合产物，传说是屠杀亵渎者用的。\n一次性发射2个下坠的星星，极弱的击退力。\n\n--只言片语：在前世，他就为了泰拉的和平而献祭自己……，\n-但这短暂的和平终究会被打破…………");
		}

		public override void SetDefaults() {
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.width = 27;
			Item.height = 27;
            Item.useTime = 20;
            Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.25f;
			Item.value = 10000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.StarWrath;
			Item.shootSpeed = 25;
			

			Item.crit = 4; // 基本暴击率加上游戏的+4基础率=8
			Item.mana = 5; // 魔法消耗
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			// Loop these functions 3 times.
			for (int i = 0; i < 2; i++)
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
				Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
			}

			return false;
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.ManaCrystal, 8);

			recipe.AddRecipeGroup("DBRecipes", 15);

			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 20);

			recipe.AddIngredient(ItemID.MeteoriteBar, 15);

			recipe.AddIngredient(ItemID.Amethyst, 3);

			recipe.AddTile(TileID.Anvils);

			recipe.Register();
		}
	}
}