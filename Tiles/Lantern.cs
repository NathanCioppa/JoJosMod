using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using JoJosMod.Items;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;

namespace JoJosMod.Tiles
{
    internal class Lantern : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);

            DustType = DustID.WhiteTorch;
            

            AddMapEntry(new Color(200, 200, 200));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {     
            r = 1;
            g = 1;
            b = 1;
        }
    }
}
