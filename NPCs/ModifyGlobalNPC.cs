using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using JoJosMod.Armor;
using JoJosMod.Items;

namespace JoJosMod.NPCs
{
    class ModifyGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.ZombieRaincoat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LittleRainHood>(), 20));
            }

            if(npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WintonOverwat>(), 1));
            }
        }
    }
}
