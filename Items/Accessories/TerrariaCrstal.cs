using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace SkyHell.Items.Accessories
{
	public class TerrariaCrstal : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("TerraCrystal");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(14, 8));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            DisplayName.AddTranslation(7,"泰拉水晶");

			Tooltip.SetDefault("Lunar Madness it's not the end,go ahead, adventurer.\n" 
			+ "It's just beginning!\n\n" 
			+ "Increase [c/ff0000:60%] damage of All Professional\n"
            + "Increases base damage by [c/00ff00:50]\n"
			+ "Increases [c/00ff55:10%] melee critical chance\n"
            + "Increases magic armor penetration by [c/ffff00:15]\n"
            + "Increases ranged shoot speed by [c/00ffff:15%]\n"
            + "After the Lunar Madness, The real journey has just begun…");

			Tooltip.AddTranslation(7, "月亮末日后并不是终点，前进吧，冒险家。一切才刚刚开始！\n\n" 
			+ "增加全职业 [c/ff0000:60%] 伤害\n"
            + "增加所有武器的总伤害 [c/00ff00:50]\n"
            + "增加近战武器暴击率 [c/00ff55:10%]\n"
            + "魔法穿透目标护甲 [c/ffff00:15] 防御点\n"
            + "远程射击速度提高 [c/00ffff:15%]\n"
            + "月亮末日过后，真正的旅途刚刚开始……");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
            Item.width = 18;
            Item.height = 18;
            Item.accessory = true;
			Item.value = Item.sellPrice(0, 80, 0, 0);
			Item.rare = -11;
		}
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
        }


        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			//灵魂精华
			recipe.AddIngredient(ItemID.Ectoplasm, 60);

			//四碎片
			recipe.AddIngredient(3456, 30);
			recipe.AddIngredient(3457, 30);
			recipe.AddIngredient(3458, 30);
			recipe.AddIngredient(3459, 30);

			//夜明锭
			recipe.AddIngredient(3467, 20);

			//生命水晶与魔力水晶
			recipe.AddIngredient(109, 5);
			recipe.AddIngredient(29, 5);

			//天界徽章
			recipe.AddIngredient(2220, 1);

			//任意职业徽章
			recipe.AddRecipeGroup("RYSRecipes", 1);

			//三王魂
			recipe.AddIngredient(ItemID.SoulofFright, 40);
			recipe.AddIngredient(ItemID.SoulofMight, 40);
			recipe.AddIngredient(ItemID.SoulofSight, 40);

			//光与黑魂
			recipe.AddIngredient(520, 30);
			recipe.AddIngredient(521, 30);

			recipe.AddTile(TileID.LunarCraftingStation);

			recipe.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			//player.GetDamage(DamageClass.Generic) += 0.30f;
			player.GetDamage(DamageClass.Generic) *= 1.06f;
			//player.GetDamage(DamageClass.Generic).Base += 14f;
			player.GetDamage(DamageClass.Generic).Flat += 50f;
			player.GetCritChance(DamageClass.Melee) += 10f;
			Item.defense = 30;
			player.GetArmorPenetration(DamageClass.Magic) += 15f;
			player.GetAttackSpeed(DamageClass.Ranged) += 0.15f;
		}


	}
}