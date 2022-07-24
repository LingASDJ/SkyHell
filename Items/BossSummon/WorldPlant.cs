using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SkyHell.Items.BossSummon
{
	// This is the Item used to summon a boss, in this case the vanilla Plantera boss.
	public class WorldPlant : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Catand
			DisplayName.SetDefault("God of plants");
			Tooltip.SetDefault("Call the flower of the century, a freak flower creeping in the depths of the jungle.");

			DisplayName.AddTranslation(7,"植物之神");
			Tooltip.AddTranslation(7,"召唤世纪之花，蔓生在丛林深处的畸形怪花。");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

			NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			// 如果你决定使用下面的 UseItem 代码，你必须包含 !NPC.AnyNPCs(id)，因为这也是服务器在接收 MessageID.SpawnBoss 时所做的检查
			return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				// 如果使用该物品的玩家是客户端
				//（这里明确排除服务器端）
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = NPCID.Plantera;

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					// 如果玩家不在多人游戏中，则直接生成
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else
				{
					// 如果玩家在多人游戏中，则请求生成
					// 这只有在 NPCID.Sets.MPAllowedEnemies[type] 为真时才有效，我们在上面的这个类中设置了
					NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
				}
			}

			return true;
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();

			recipe.AddIngredient(ItemID.JungleSpores, 5);

			recipe.AddIngredient(ItemID.LifeFruit, 1);

			recipe.AddIngredient(ItemID.Vine, 10);

			recipe.AddIngredient(ItemID.JungleGrassSeeds, 5);

			recipe.AddIngredient(520, 5);

			recipe.AddTile(TileID.DemonAltar);

			recipe.Register();
		}
	}
}