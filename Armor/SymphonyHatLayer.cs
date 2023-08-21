
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ReLogic.Content;
using JoJosMod.Players;
using System.Linq;

namespace JoJosMod.Armor
{
    internal class SymphonyHatLayer : PlayerDrawLayer
    {
        public Asset<Texture2D> hatTexture;
        public override bool IsHeadLayer => true;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return drawInfo.drawPlayer.GetModPlayer<SymphonyHatPlayer>().isWearingShmphonyHat;
        }

        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);
        

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.drawPlayer.DeadOrGhost) return;

            hatTexture ??= ModContent.Request<Texture2D>("JoJosMod/Armor/SymphonyHat");
            
            const int FrameHeight = 56;
            int[] highFrames = new int[] {7,8,9,14,15,16};
            int playerFrameY = Main.player[Main.myPlayer].legFrame.Y;
                        

            var position = drawInfo.Center + new Vector2(drawInfo.drawPlayer.direction > 0 ? -18 : -12, highFrames.Contains(playerFrameY/FrameHeight) ? -49 : -47) - Main.screenPosition;
            position = new Vector2((int)position.X, (int)position.Y);

            DrawData drawData = new(
                hatTexture.Value,
                position,
                null,
                Lighting.GetColor(drawInfo.drawPlayer.position.ToTileCoordinates()),
                0,
                drawInfo.rotationOrigin,
                1f,
                drawInfo.drawPlayer.direction > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);

            drawInfo.DrawDataCache.Add(drawData);
        }
    }
}
