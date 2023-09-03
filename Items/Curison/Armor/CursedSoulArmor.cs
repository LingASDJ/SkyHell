using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SkyHell.Items.Curison.Armor
{

    [AutoloadEquip(EquipType.Body)]
    public class CursedSoulArmor : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Purple;
            Item.vanity = false;
            Item.maxStack = 1;
            Item.defense = 7;
        }

        public static int MagicMax = 15;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MagicMax);
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 15;
        }
    }
}