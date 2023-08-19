
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ReLogic.Content;
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
            if (drawInfo.drawPlayer.DeadOrGhost) return;

            hatTexture ??= ModContent.Request<Texture2D>("JoJosMod/Armor/SymphonyHat");

            var position = drawInfo.Center + new Vector2(drawInfo.drawPlayer.direction > 0 ? -18 : -12, -47) - Main.screenPosition;
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
