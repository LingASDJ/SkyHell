using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace SkyHell.Items.Accessories
{
	public class TerrariaCrstal : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("等待翻译");

			DisplayName.AddTranslation(7,"泰拉水晶");

			//Catand
			Tooltip.SetDefault("等待翻译");

			Tooltip.AddTranslation(7, "月亮末日后并不是终点，前进吧，孩子。一切才刚刚开始！\n\n增加 10% 伤害\n"
			+ "增加 30% 倍数伤害\n"
			+ "增加所有武器的基础伤害 14\n"
			+ "增加所有武器的总伤害 25\n"
			+ "增加近战武器暴击率10%\n"
			+ "魔法穿透目标护甲 15 防御点\n"
			+ "远程射击速度提高 15%\n"
			+ "只言片语：月亮末日过后，真正的旅途刚刚开始……");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 80, 0, 0);
			Item.rare = -12;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			//灵魂精华
			recipe.AddIngredient(ItemID.Ectoplasm, 30);

			//四碎片
			recipe.AddIngredient(3456, 20);
			recipe.AddIngredient(3457, 20);
			recipe.AddIngredient(3458, 20);
			recipe.AddIngredient(3459, 20);

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
			recipe.AddIngredient(520, 10);
			recipe.AddIngredient(521, 10);

			recipe.AddTile(TileID.LunarCraftingStation);

			recipe.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Generic) += 0.30f;
			player.GetDamage(DamageClass.Generic) *= 1.08f;
			player.GetDamage(DamageClass.Generic).Base += 14f;
			player.GetDamage(DamageClass.Generic).Flat += 25f;
			player.GetCritChance(DamageClass.Melee) += 10f;
			Item.defense = 15;
			player.GetArmorPenetration(DamageClass.Magic) += 15f;
			player.GetAttackSpeed(DamageClass.Ranged) += 0.15f;
		}


	}
}