using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SkyHell.Content
{
    public class SkyHellRecipes : ModSystem
    {
        //生命水晶
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
            RecipeGroup recipeGroupone = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.DBTitle"), //游戏显示合成组的名字
                new int[]
                {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
                });//添加ID

            RecipeGroup.RegisterGroup("DBRecipes", recipeGroupone);

            RecipeGroup recipeGrouptwo = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.EZTitle"), //游戏显示合成组的名字
                new int[]
                {
                763,
                61
                });//添加ID
            RecipeGroup.RegisterGroup("FXRecipes", recipeGrouptwo);

            RecipeGroup recipeGroupthree = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.TNTitle"),
                new int[]
                {
                1329,
                86
                });//添加ID
            RecipeGroup.RegisterGroup("TNRecipes", recipeGroupthree);

            //"任意新三王掉落的魂", //游戏显示合成组的名字
            RecipeGroup recipeGroupfour = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.STitle"),
                new int[]
                {
                ItemID.SoulofFright,
                ItemID.SoulofMight,
                ItemID.SoulofSight,
                });//添加ID

            RecipeGroup.RegisterGroup("SHKRecipes", recipeGroupfour);

            RecipeGroup recipeGroupfive = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.STitle"),
                ModContent.ItemType<Items.Wands.PinkCrystalSkyWands>());

            RecipeGroup.RegisterGroup("PinkWandsRecipes", recipeGroupfive);

            RecipeGroup recipeGroupsix = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.DSTitle"),
                new int[]
                {
                795,
                46,
                });//添加ID

            RecipeGroup.RegisterGroup("EARecipes", recipeGroupsix);

            RecipeGroup recipeGroupseven = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.TJitle"),
            new int[]
            {
                        ItemID.AdamantiteBar,
                        ItemID.TitaniumBar
            });//添加ID

            RecipeGroup.RegisterGroup("TJRecipes", recipeGroupseven);

            RecipeGroup recipeGroupeight = new RecipeGroup(() => Language.GetTextValue("Mods.SkyHell.Config.Title.ZYSTitle"),
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