using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Content
{
	public class SkyHellRecipes : ModSystem
	{

		public override void AddRecipes()
		{
			Recipe baseRecipe = Recipe.Create(ItemID.LifeCrystal, 1);
			baseRecipe.AddIngredient(ItemID.HealingPotion, 1)
			.AddRecipeGroup("FXRecipes", 30)
			.AddRecipeGroup("TNRecipes", 5)

			.AddTile(TileID.Anvils)
			.Register();
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup recipeGroupone = new RecipeGroup(() => "任意魔矿", //游戏显示合成组的名字
				new int[]
				{
				ItemID.DemoniteBar,
				ItemID.CrimtaneBar
				});//添加ID

			RecipeGroup.RegisterGroup("DBRecipes", recipeGroupone);

			RecipeGroup recipeGrouptwo = new RecipeGroup(() => "任意恶地地块", //游戏显示合成组的名字
				new int[]
				{
				763,
				61
				});//添加ID
			RecipeGroup.RegisterGroup("FXRecipes", recipeGrouptwo);

			RecipeGroup recipeGroupthree = new RecipeGroup(() => "任意恶地首领战利品\n([c/00ffff:暗影磷片x5]或[c/00ffff:组织样本x5])", //游戏显示合成组的名字
				new int[]
				{
				1329,
				86
				});//添加ID
			RecipeGroup.RegisterGroup("TNRecipes", recipeGroupthree);

			RecipeGroup recipeGroupfour = new RecipeGroup(() => "任意新三王掉落的魂", //游戏显示合成组的名字
				new int[]
				{
				ItemID.SoulofFright,
				ItemID.SoulofMight,
				ItemID.SoulofSight,
				});//添加ID

			RecipeGroup.RegisterGroup("SHKRecipes", recipeGroupfour);

			RecipeGroup recipeGroupfive = new RecipeGroup(() => "紫晶天空法杖",
				ModContent.ItemType<Items.Wands.PinkCrystalSkyWands>());

			RecipeGroup.RegisterGroup("PinkWandsRecipes", recipeGroupfive);

			RecipeGroup recipeGroupsix = new RecipeGroup(() => "任意恶地剑", //游戏显示合成组的名字
				new int[]
				{
				795,
				46,
				});//添加ID

			RecipeGroup.RegisterGroup("EARecipes", recipeGroupsix);

			RecipeGroup recipeGroupseven = new RecipeGroup(() => "精金或钛金", //游戏显示合成组的名字
			new int[]
			{
						ItemID.AdamantiteBar,
						ItemID.TitaniumBar
			});//添加ID

			RecipeGroup.RegisterGroup("TJRecipes", recipeGroupseven);

			RecipeGroup recipeGroupeight = new RecipeGroup(() => "任意职业徽章", //游戏显示合成组的名字
			new int[]
			{
						ItemID.SorcererEmblem,
						ItemID.WarriorEmblem,
						ItemID.RangerEmblem,
						ItemID.SummonerEmblem,

			});//添加ID

			RecipeGroup.RegisterGroup("RYSRecipes", recipeGroupeight);

		}
	}
}