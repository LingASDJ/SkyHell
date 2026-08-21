using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace SkyHell.Content
{
    public class SkyHellRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe.Create(ItemID.LifeCrystal, 1)
                .AddIngredient(ItemID.HealingPotion, 1)
                .AddRecipeGroup("FXRecipes", 30)
                .AddRecipeGroup("TNRecipes", 5)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void AddRecipeGroups()
        {
            // 1. 魔矿锭/猩红矿锭
            RecipeGroup.Register("DBRecipes", "Mods.SkyHell.Config.Title.DBTitle",
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            );

            // 2. FXRecipes (763=丛林孢子, 61=丛林玫瑰)
            RecipeGroup.Register("FXRecipes", "Mods.SkyHell.Config.Title.EZTitle",
                763,
                61
            );

            // 3. TNRecipes (1329=毒刺, 86=蚁狮上颚)
            RecipeGroup.Register("TNRecipes", "Mods.SkyHell.Config.Title.TNTitle",
                1329,
                86
            );

            // 4. 新三王魂
            RecipeGroup.Register("SHKRecipes", "Mods.SkyHell.Config.Title.SHKTitles",  // 建议修改键名避免重复
                ItemID.SoulofFright,
                ItemID.SoulofMight,
                ItemID.SoulofSight
            );

            // 5. 粉晶法杖（单物品组）
            RecipeGroup.Register("PinkWandsRecipes", "Mods.SkyHell.Config.Title.PinkTitle",  // 建议修改键名
                ModContent.ItemType<Items.Wands.PinkCrystalSkyWands>()
            );

            // 6. EARecipes (795=珍珠木, 46=?)
            RecipeGroup.Register("EARecipes", "Mods.SkyHell.Config.Title.DSTitle",
                795,
                46
            );

            // 7. 精金/钛金锭
            RecipeGroup.Register("TJRecipes", "Mods.SkyHell.Config.Title.TJTitle",
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            );

            // 8. 职业徽章
            RecipeGroup.Register("RYSRecipes", "Mods.SkyHell.Config.Title.ZYSTitle",
                ItemID.SorcererEmblem,
                ItemID.WarriorEmblem,
                ItemID.RangerEmblem,
                ItemID.SummonerEmblem
            );
        }
    }
}