using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Items.Gun
{
	public class GoldKingGun : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Royal defense shotgun");
			Tooltip.SetDefault("A shotgun from the royal family，It uses ammo bullet as bullets. [c/00ffff:Joined the blessing of the soul, now it can be stronger than ever!]\n\n"
			+ " the glory of the royal family is here!");

			DisplayName.AddTranslation(7,"皇家防卫霰弹机枪");
			Tooltip.AddTranslation(7,"来自于皇家的御用枪械，用火枪作为子弹\n[c/00ffff:加入了灵魂的祝福，现在能比曾经的更强！]\n\n皇家的荣光，在这里显现！");
		}

		public override void SetDefaults()
		{
			Item.width = 62;
			Item.height = 32;
			Item.rare = ItemRarityID.Red;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(0, 70, 70, 0);
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item36;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 6;
			Item.knockBack = 6f;
			Item.noMelee = true;

			Item.crit = 3;

			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 12; // The humber of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++)
			{
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				Item.shoot = ProjectileID.PurificationPowder;
				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6f, -2f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.SoulofSight, 25);

			recipe.AddIngredient(ItemID.SoulofFright, 25);

			recipe.AddIngredient(ItemID.SoulofMight, 25); 

			recipe.AddIngredient(ModContent.ItemType<Items.Gun.GoldGun>(), 1);

			recipe.AddTile(TileID.MythrilAnvil);

			recipe.Register();
		}
	}
}
