using SkyHell.Items.Curison;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkyHell.Content
{
    public class DryadShopConditional : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Dryad)
            {
                shop.Add<GhostTach>();
            }
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Dryad)
                return;

            bool night = !Main.dayTime;

            bool canBuy = night;

            int itemType = ModContent.ItemType<GhostTach>();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null && items[i].type == itemType)
                {
                    items[i].value = Item.buyPrice(0, 32, 5, 799);
                    if (!canBuy)
                    {
                        items[i].TurnToAir();
                    }
                    break;
                }
            }
        }
    }
}