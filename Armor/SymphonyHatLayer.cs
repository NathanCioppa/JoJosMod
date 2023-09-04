
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ReLogic.Content;
using System.Linq;
using JoJosMod.Players;

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
            Player player = drawInfo.drawPlayer;

            if (player.DeadOrGhost) return;

            hatTexture ??= ModContent.Request<Texture2D>("JoJosMod/Armor/SymphonyHat");

            int[] highFrames = new int[] {7,8,9,14,15,16};
            int bodyFrameHeight = player.bodyFrame.Height;
            int playerBodyFrameY = player.bodyFrame.Y;
            int playerBodyFrame = playerBodyFrameY / bodyFrameHeight;
            bool isHighFrame = highFrames.Contains(playerBodyFrame);

            int drawOffsetY = -26;
            if (isHighFrame) drawOffsetY -= 2;
            int drawOffsetX = player.direction < 0 ? -4:-6;

            var position = drawInfo.Position + new Vector2(drawOffsetX,drawOffsetY) - Main.screenPosition;
            position = new Vector2((int)position.X, (int)position.Y);

            DrawData drawData = new
            (
                hatTexture.Value,
                position,
                null,
                drawInfo.colorArmorHead,
                0,
                drawInfo.rotationOrigin,
                1f,
                player.direction < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None
            );

            int dyeShader = player.dye?[0].dye ?? 0;
            drawData.shader = dyeShader;

            drawInfo.DrawDataCache.Add(drawData);
        }
    }
}