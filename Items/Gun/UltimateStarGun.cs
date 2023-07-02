using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Items.Gun
{
	public class UltimateStarGun : ModItem
	{
		//public override void SetStaticDefaults()
		//{

			// DisplayName.SetDefault("Extreme star cannon");
			/* Tooltip.SetDefault("Oh, my God. You have obtained the unparalleled extreme star cannon.\n"
			+ "Now, who is the real master of the sky? There is a 35% probability that ammunition will not be consumed.\n"
			+ "If there is no ammunition and the backpack carries a heaven badge, the next shooting true star cannon mode will be activated.\n"
			+ "Rainbow tracking missiles can be launched before exiting the game without consuming ammunition…\n\n"
			+ " the instant the stars fall, the fleeting light is also very beautiful…"); */

			//DisplayName.AddTranslation(7,"究极星星炮");
			//Tooltip.AddTranslation(7,"哦，天哪。你获得了无与伦比的究极星星炮。\n现在，谁才是真正的天空之主？有35%的概率不消耗弹药。\n如果没有弹药且背包携带有天界徽章，则下一次射击真-星星炮模式将被激活。\n在退出游戏前均可发射彩虹跟踪导弹且不消耗弹药……\n\n星空下坠的瞬间，转瞬即逝的耀光也很美丽……");
		//}

		public override void SetDefaults()
		{
			
			Item.width = 22; 
			Item.height = 22; 
			Item.rare = 9; 
			Item.crit = 24;
			Item.value = Item.sellPrice(0, 20, 10, 0);
			Item.useTime = 5;
			Item.useAnimation = 5; 
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.autoReuse = true; 
			Item.UseSound = SoundID.Item1; 

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; 
			Item.damage = 120; 
			Item.knockBack = 1f; 
			Item.noMelee = true; // So the item's animation doesn't do damage.

			// Gun Properties
			Item.shoot = ProjectileID.StarWrath; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.FallenStar;
		}

		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
				return Main.rand.NextFloat() >= 0.35f;			
			
		}

		//没有弹药的时候有一个天界徽章开启真-星星炮模式
		public override bool NeedsAmmo(Player player)
		{
			Item.damage = 80;
			Item.crit = 22;
			Item.shoot = ProjectileID.RainbowRodBullet; // For some reason, all the guns in the vanilla source have this.
			return player.CountItem(2220, 1) < 1;
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6f, -2f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.SuperStarCannon, 1);

			recipe.AddIngredient(ItemID.SoulofSight, 25);

			recipe.AddIngredient(ItemID.SoulofFright, 25);

			recipe.AddIngredient(ItemID.SoulofMight, 25);

			recipe.AddIngredient(ItemID.CrystalShard, 10);

			recipe.AddRecipeGroup("TJRecipes", 20);

			recipe.AddTile(TileID.MythrilAnvil);

			recipe.Register();
		}
	}
}
