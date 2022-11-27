using SkyHell.Buff;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SkyHell.Items.Potions
{

        // 保证类名跟文件名一致，这样也方便查找
        public class PotionOfHealing : ModItem
        {

            // 设置物品名字，描述的地方，这个函数需要记住
            public override void SetStaticDefaults()
            {

                // 这个是物品名字，也就是忽略游戏语言的情况下显示的文字
                DisplayName.SetDefault("治疗药（）");
              

                // 物品的描述，加入换行符 '\n' 可以多行显示哦
                Tooltip.SetDefault("喝了可以立刻回满血量，但会获得一会燃烧效果，此时玩家暴击率翻倍");
            }


            public override void SetDefaults()
            {
                // 这部分就不说了
                Item.width = 14;
                Item.height = 24;

            Item.useAnimation = 45;
            Item.useTime = 45;

            Item.rare = ItemRarityID.Pink;
                Item.value = Item.sellPrice(0, 0, 50, 0);


            // 物品的使用方式，还记得2是什么吗
            Item.useStyle = ItemUseStyleID.EatFood;
            // 喝药的声音
            Item.UseSound = SoundID.Item3;

            Item.maxStack = 30;

                // 决定这个物品使用以后会不会减少，true就是使用后物品会少一个，默认为false
                Item.consumable = true;
                // 决定使用动画出现后，玩家转身会不会影响动画的方向，true就是会，默认为false
                Item.useTurn = true;
                // 告诉TR内部系统，这个物品是一个生命药水物品，用于TR系统的特殊目的（比如一键喝药水），默认为false
                Item.potion = false;
            // 这个药水能给玩家加多少血，跟potion一起使用喝完药就会有抗药性debuff
            Item.healLife += 50;
            // 加buff的方法1：设置物品的buffType为buff的ID
            // 这里我设置了着火debuff（2333
            Item.buffType = BuffID.Ironskin;
            // 用于在物品描述上显示buff持续时间
                Item.buffTime = 600;
            }

            // 当物品使用的时候触发，返回值貌似是什么都不会有影响
            //public override bool? UseItem(Player player)
            //{
            //// 给玩家加上中毒buff，持续 60000 / 60 = 1000秒
            //// 第一个填buff的ID，第二个填持续时间
            ////player.AddBuff(ModContent.BuffType<SuperToxic>(), 300);
            ////player.AddBuff(BuffID.Poisoned, 60000);
            ////// 给玩家加上猛毒buff，持续 60000 / 60 = 1000秒 
            ////player.AddBuff(BuffID.Venom, 60000);
            ////// 嘿嘿
            ////player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " 喝农药被毒死了"), 9999, 0);
            //player.AddBuff(ModContent.BuffType<WhatBuff>(), 600);


            //return false;
            //}

            // 物品合成表的设置部分
            public override void AddRecipes()
            {
                CreateRecipe(99)
                    .AddIngredient(ItemID.GoldBar, 5)
                    .AddIngredient(ItemID.IronBar, 5)
                    .AddIngredient(ItemID.Torch, 25)
                    .AddTile(TileID.WorkBenches)
                    .AddTile(TileID.Anvils)
                    .Register();

            }
        }
}
