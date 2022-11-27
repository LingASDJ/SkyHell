using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Items.Gun
{
	public class GoldGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("Royal machine gun");

			DisplayName.AddTranslation(7, "皇家机枪");

			//Catand
			Tooltip.SetDefault("A machine gun from the royal family，It uses ammo bullet as bullets. \n"
			+ "It is said that the Royal craftsman, \n"
			+ "fused [c/ffff00:illegal gun parts] and [c/ffff00:gold] to create a very powerful high-speed machine gun, \n"
			+ "It can instantly turn the target into a hornet's nest! \n\n"
			+ "A word: the glory of the royal family is here! ");

			Tooltip.AddTranslation(7, "来自于皇家的御用枪械，用火枪作为子弹\n传言是皇家工匠，\n将[c/ffff00:非法枪械部件]以及[c/ffff00:黄金]融合造就的一把非常厉害的高速机枪，\n能将目标瞬间打成马蜂窝！\n\n只言片语：皇家的荣光，在这里显现！");
		}

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 22;
			Item.rare = 9;
			Item.crit = 5;
			Item.value = Item.sellPrice(0, 10, 10, 10);
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 20;
			Item.knockBack = 1f;
			Item.noMelee = true; // So the item's animation doesn't do damage.

			// Gun Properties
			Item.shoot = ProjectileID.BallofFire; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 85f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet;
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6f, -2f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.GoldBar, 40);

			recipe.AddIngredient(ItemID.GoldCoin, 25);

			recipe.AddIngredient(ItemID.IllegalGunParts, 2);

			recipe.AddIngredient(ItemID.FlareGun, 1);

			recipe.AddTile(TileID.Anvils);

			recipe.Register();
		}
	}
}

/*
 光栅化
 */
