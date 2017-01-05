using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace OnionMaster
{
    class GraphicWrapper : IGraphic
    {
        public void Init()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }

        public int InitTileTexture(Bitmap bitmap)
        {
            int textureId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height,
                0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);
            return textureId;
        }

        public void ActivateTileTexture(int textureId, int width, int height)
        {
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.MatrixMode(MatrixMode.Texture);
            GL.LoadIdentity();
            GL.Scale(1.0 / width, 1.0 / height, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void Resize(int width, int height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, width / 2.0, 0.0, height / 2.0, 0.0, 4.0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Viewport(0, 0, width, height);
        }

        public void Draw(int tileX, int tileY, int screenX, int screenY, int width, int height)
        {
            var t1 = new Vector2(tileX, tileY);
            var t2 = new Vector2(tileX + width, tileY + height);
            var s1 = new Vector2(screenX, screenY);
            var s2 = new Vector2(screenX + width, screenY + height);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(t1.X, t2.Y);
            GL.Vertex2(s1);

            GL.TexCoord2(t2);
            GL.Vertex2(s2.X, s1.Y);

            GL.TexCoord2(t2.X, t1.Y);
            GL.Vertex2(s2);

            GL.TexCoord2(t1);
            GL.Vertex2(s1.X, s2.Y);
            GL.End();
        }
    }
}
