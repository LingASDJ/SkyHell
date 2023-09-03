using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SkyHell.Items.Curison.Armor
{

    public class CursedSoulLegSkill : ModPlayer
    {
        public override bool IsCloneable => true;

        public bool Enable;
        public override void ResetEffects()
        {
            Enable = false;
            base.ResetEffects();
        }

        public override void NaturalLifeRegen(ref float regen)
        {
            if (Enable)
            {
                //恢复量原有基础上提升10%
                regen *= 1.1f;
            }
            base.NaturalLifeRegen(ref regen);
        }
    }

    [AutoloadEquip(EquipType.Legs)]
    public class CursedSoulLeg : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Purple;
            Item.vanity = false;
            Item.maxStack = 1;
            Item.defense = 5;
        }

        public static float moveSpeed = 15f;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(moveSpeed);

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= moveSpeed/10;
            player.GetModPlayer<CursedSoulLegSkill>().Enable = true;
        }

    }
}
