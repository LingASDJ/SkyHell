using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SkyHell.Utils;
using SkyHell.Buff;

namespace SkyHell.Projectiles
{
    public class FireBallBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("学习弹幕");
        }

        public override void SetDefaults()
        {
            //弹幕通常是头朝上绘制的
            Projectile.width = 8;
            Projectile.width = 8;
            //控制弹幕的大小 DrawSize
            Projectile.scale = 1.5f;
            //是否对敌对NPC造成伤害？
            Projectile.friendly = true;
            //能否对NPC以及玩家造成伤害？
            //你是个可怕的人！！！
            Projectile.hostile = false;
            //吃魔法伤害加成类型的弹幕
            Projectile.damage = 100;
            Projectile.DamageType = DamageClass.Melee;
            //弹幕在水中会不会减速？ True为会 False不会 (默认True)
            Projectile.ignoreWater = true;
            //弹幕的存活生命周期 60帧=1秒 10秒 600/60
            Projectile.timeLeft = 600;
            //弹幕为True撞到物块消失 反之则穿墙（月球领主：你最好有事）
            Projectile.tileCollide = true;

            //弹幕穿透性，打中几个怪物后才消失
            //-1则为无限穿透（
            Projectile.penetrate = 5;
            //弹幕的透明度 0-255 默认为0 255则完全透明
            //Projectile.alpha = 0;
            //光照强度 只能让弹幕发出白光 后面的数值是光的强度
            Projectile.light = 1.5f;
            //弹幕的AI类型，自定义选择-1。
            
            //继承原版的一种弹幕的AI类型
            AIType = ModContent.ProjectileType<ProjProj>();
        }

        public override void AI()
        {
            //Vector2 PlayerPoison = new Vector2(Xp,Yp);
            //Vector2 MousePoison = new Vector2(Xm, Ym);


            // 假设我设置弹幕消散时间为600
            if (Projectile.timeLeft < 597)
            {
                // 火焰粒子特效
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height
                    , MyDustId.IceTorch, 0f, 0f, 100, default(Color), 3f);
                // 粒子特效不受重力
                dust.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
            {
                // 生成dust
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height,
                    MyDustId.DemonTorch, 0, 0, 100, Color.White, 1.5f);

                // 粒子效果无重力
                d.noGravity = true;
                // 粒子效果初速度乘以二
                d.velocity *= 2;

            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<WhatBuff>(), 600);
        }
        //public override bool OnTileCollide(Vector2 oldVelocity)
        //{
        //    if (Projectile.velocity.X != oldVelocity.X)
        //    {
        //        Projectile.velocity.X = -oldVelocity.X;
        //    }
        //    if (Projectile.velocity.Y != oldVelocity.Y)
        //    {
        //        Projectile.velocity.Y = -oldVelocity.Y;
        //    }
        //    return false;
        //}

    }
}
