using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using SkyHell.Utils;
using SkyHell.Buff;
using SkyHell.Projectiles;

namespace SkyHell.Items.Tools
{
    public class ThunderPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {

            // 这个是物品名字，也就是忽略游戏语言的情况下显示的文字
            DisplayName.SetDefault("Thunder Pickaxe");


            // 物品的描述，加入换行符 '\n' 可以多行显示哦
            Tooltip.SetDefault("你这镐子是金子做的还是银子做的?");
        }

        public override void SetDefaults()
        {
            //镐力
            //Item.pick = 120;
            Item.width = 14;
            Item.height = 24;
            Item.useAnimation = 12;
            Item.useTime = 3;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = 1;
            //Item.hammer = 100;
            //Item.axe = 50;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<YinYangTower>();
            Item.shootSpeed = 10f;
            Item.damage = 100;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(hitbox.TopLeft(), hitbox.Width, hitbox.Height, MyDustId.BlueMagic ,0, 0, 100, Color.SkyBlue, 4.0f);
        }

    }
}
