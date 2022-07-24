


using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


namespace SkyHell.Items.Sword
{
	public class BloodFireSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("等待翻译");
			Tooltip.SetDefault("等待翻译");

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
			Item.shoot = ProjectileID.DD2PhoenixBowShot;
			Item.shootSpeed = 20;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (Main.rand.Next(100) <= 10)
			{
				Item.shoot = ProjectileID.DD2PhoenixBowShot;
				return false;
			}

			else if (Main.rand.Next(100) >= 80)
			{
				Item.shoot = ProjectileID.NebulaArcanum;
				return false;
			}

			else if (Main.rand.Next(100) >= 0)
			{
				Item.shoot = ProjectileID.FairyQueenMagicItemShot;
				return true;
			}

			return true;

		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{

			target.AddBuff(BuffID.BrainOfConfusionBuff, 10);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height,
				DustID.GemTopaz, 0, 0, 100, Color.White, 1);

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