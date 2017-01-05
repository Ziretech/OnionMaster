using System.Drawing;

namespace OnionMaster
{
    public interface IGraphic
    {
        void Init();

        int InitTileTexture(Bitmap bitmap);

        void ActivateTileTexture(int textureId, int width, int height);

        void Clear();

        void Resize(int width, int height);

        void Draw(int tileX, int tileY, int screenX, int screenY, int width, int height);
    }
}