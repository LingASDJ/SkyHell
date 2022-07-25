using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{

	public class PreFixedMagicNormal : ModPrefix
	{

		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Magic;

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override float RollChance(Item item)
		{
			return 1.4f;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			manaMult *= 1+0.71f * Power;
			critBonus += 58;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1f + 0.5f * Power;
		}

		public override void Apply(Item item)
		{
		}
	}
}
