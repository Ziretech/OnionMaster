using NUnit.Framework;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace UseCaseLayer.Rendering
{
    [TestFixture]
    public class ShowAllRenderableObjects_RenderTiledAreaTest
    {
        [Test]
        public void Should_find_1_render_info_from_a_1_tile_tiledArea()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    TiledArea = new TiledArea(
                        new TileDimension(1, 2),
                        new List<TileSetCoordinate> { new TileSetCoordinate(0, 3, 4) },
                        5,
                        new List<int> { 0 }),
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowTiledAreaObjects(world).Render();
            Assert.That(renderInfos.Count, Is.EqualTo(1));
            Assert.That(renderInfos.First(), Is.EqualTo(new RenderInfo(5, 6, 7, 0, 3, 4, 1, 2)));
        }

        [Test]
        public void Should_find_2_render_info_from_2_1tile_tiledArea()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    TiledArea = new TiledArea(
                        new TileDimension(1, 2),
                        new List<TileSetCoordinate> { new TileSetCoordinate(0, 3, 4) },
                        5,
                        new List<int> { 0 }),
                    Position = new Position(5, 6, 7)
                },
                new GameObject
                {
                    TiledArea = new TiledArea(
                        new TileDimension(1, 2),
                        new List<TileSetCoordinate> { new TileSetCoordinate(0, 3, 4) },
                        5,
                        new List<int> { 0 }),
                    Position = new Position(6, 6, 7)
                }
            });
            var renderInfos = new ShowTiledAreaObjects(world).Render();
            Assert.That(renderInfos.Count, Is.EqualTo(2));
            Assert.That(renderInfos.ElementAt(0), Is.EqualTo(new RenderInfo(5, 6, 7, 0, 3, 4, 1, 2)));
            Assert.That(renderInfos.ElementAt(1), Is.EqualTo(new RenderInfo(6, 6, 7, 0, 3, 4, 1, 2)));
        }

        [Test]
        public void Should_generate_render_info_from_specified_tile()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    TiledArea = new TiledArea(
                        new TileDimension(1, 2),
                        new List<TileSetCoordinate>
                        {
                            new TileSetCoordinate(1, 2, 3),
                            new TileSetCoordinate(4, 5, 6)
                        },
                        5,
                        new List<int> { 1 }),
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowTiledAreaObjects(world).Render();
            Assert.That(renderInfos.First(), Is.EqualTo(new RenderInfo(5, 6, 7, 4, 5, 6, 1, 2)));
        }

        [Test]
        public void Should_generate_render_info_for_every_index()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    TiledArea = new TiledArea(
                        new TileDimension(1, 2),
                        new List<TileSetCoordinate>
                        {
                            new TileSetCoordinate(1, 2, 3),
                            new TileSetCoordinate(4, 5, 6)
                        },
                        5,
                        new List<int> { 1, 0 }),
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowTiledAreaObjects(world).Render();
            Assert.That(renderInfos.Count, Is.EqualTo(2));
            Assert.That(renderInfos.ElementAt(0), Is.EqualTo(new RenderInfo(5, 6, 7, 4, 5, 6, 1, 2)));
            Assert.That(renderInfos.ElementAt(1), Is.EqualTo(new RenderInfo(5, 6, 7, 1, 2, 3, 1, 2)));
        }

        [Test]
        public void Should_not_find_render_info_from_an_object_missing_position()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    TiledArea = new TiledArea(
                        new TileDimension(1, 2),
                        new List<TileSetCoordinate> { new TileSetCoordinate(0, 3, 4) },
                        5,
                        new List<int> { 0 }),
                    Position = null
                }
            });
            var renderInfos = new ShowTiledAreaObjects(world).Render();
            Assert.That(renderInfos, Is.Empty);
        }

        [Test]
        public void Should_not_find_render_info_from_an_object_missing_tiled_area()
        {
            var world = new GameWorld(new List<GameObject> {
                new GameObject
                {
                    TiledArea = null,
                    Position = new Position(5, 6, 7)
                }
            });
            var renderInfos = new ShowTiledAreaObjects(world).Render();
            Assert.That(renderInfos, Is.Empty);
        }
    }
}
