using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SkyHell.Items.Curison.Armor
{

    [AutoloadEquip(EquipType.Head)]
    public class CursedSoulSummonHood : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Purple;
            Item.vanity = false;
            Item.maxStack = 1;
            Item.defense = 4;
        }

        //套装奖励判定
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<CursedSoulArmor>() && legs.type == ModContent.ItemType<CursedSoulLeg>();
        }

        //套装奖励
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.SkyHell.Items.CursedSoulSummon.Ling");
            player.maxMinions += 2;
            player.GetCritChance(DamageClass.Summon) += 6f;
        }

        public static int MagicManaMax = 30;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MagicManaMax);

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += MagicManaMax;
        }


    }
}