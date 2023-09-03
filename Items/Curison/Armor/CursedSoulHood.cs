using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SkyHell.Items.Curison.Armor
{

    [AutoloadEquip(EquipType.Head)]
    public class CursedSoulHood : ModItem
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

        public static int MagicManaMax = 30;
        public static float ManaRegen = 0.15f;
        public static float ManaCost = 15f;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MagicManaMax,ManaRegen, ManaCost);

        //套装奖励
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus =
                Language.GetTextValue("Mods.SkyHell.MagicRegen") + ManaRegen+
                Language.GetTextValue("Mods.SkyHell.ManaCost") + ManaCost;
            player.GetDamage(DamageClass.Magic) += ManaRegen;
            player.manaCost -= ManaCost;
        }



        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += MagicManaMax;
        }


    }
}
