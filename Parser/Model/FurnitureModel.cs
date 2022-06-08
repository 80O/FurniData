using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniParser.Model
{
    public class Action
    {
        public int StartState { get; set; }
        public string Link { get; set; }
    }

    public class AllLayer
    {
        public string Id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
        public string Alpha { get; set; }
        public string IgnoreMouse { get; set; }
        public string BlendMode { get; set; }
        public string Tag { get; set; }
        public Offset Offset { get; set; }
    }

    public class Animation
    {
        public int Id { get; set; }
        public int RandomStart { get; set; }
        public string TransitionFrom { get; set; }
        public string TransitionTo { get; set; }
        public string ImmediateChangeFrom { get; set; }
        public List<Layer> Layers { get; set; }
    }

    public class AsAssets
    {
        public List<AssetDataMapping> AssetDataMapping { get; set; }
    }

    public class Asset
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int FlipH { get; set; }
        public int FlipV { get; set; }
        public int UsesPalette { get; set; }
        public List<Asset> Assets { get; set; }
    }

    public class AssetDataMapping
    {
        public string FileName { get; set; }
        public string Source { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
    }

    public class Credits
    {
        public int credits { get; set; }
    }

    public class DefaultDirection
    {
        public int Id { get; set; }
        public List<object> Layers { get; set; }
        public List<AllLayer> AllLayers { get; set; }
    }

    public class DefaultVisualization
    {
        public int Size { get; set; }
        public int Angle { get; set; }
        public List<Direction> Directions { get; set; }
        public List<object> Colors { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Animation> Animations { get; set; }
        public int LayerCount { get; set; }
        public int DefaultDirPopulated { get; set; }
        public DefaultDirection DefaultDirection { get; set; }
        public int DirsPopulated { get; set; }
    }

    public class Dimensions
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Z { get; set; }
        public int CenterZ { get; set; }
    }

    public class Direction
    {
        public int Id { get; set; }
        public List<object> Layers { get; set; }
        public List<AllLayer> AllLayers { get; set; }
    }

    public class Emitter
    {
        public int LifeTime { get; set; }
        public int IsEmitter { get; set; }
        public List<object> Frames { get; set; }
        public int Id { get; set; }
        public int SpriteId { get; set; }
        public string ExplosionAnimation { get; set; }
        public int FuseTime { get; set; }
        public string Name { get; set; }
        public int MaxNumParticles { get; set; }
        public int ParticlesPerFrame { get; set; }
        public int BurstPulse { get; set; }
        public Simulation Simulation { get; set; }
        public List<object> ParticlesArr { get; set; }
        public List<object> ParticlesList { get; set; }
    }

    public class Frame
    {
        public List<object> OffsetsXOffsets { get; set; }
        public List<object> OffsetsYOffsets { get; set; }
        public int RandomX { get; set; }
        public int RandomY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public int Repeats { get; set; }
    }

    public class FrameSequence
    {
        public List<Frame> Frames { get; set; }
        public List<int> FrameIndexes { get; set; }
        public List<int> FrameRepeats { get; set; }
        public int LoopCount { get; set; }
        public int Random { get; set; }
    }

    public class Index
    {
        public string Type { get; set; }
        public string Visualization { get; set; }
        public string Logic { get; set; }
    }

    public class Layer
    {
        public string Id { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
        public string Alpha { get; set; }
        public string IgnoreMouse { get; set; }
        public string BlendMode { get; set; }
        public string Tag { get; set; }
        public Offset Offset { get; set; }
        public string LoopCountString { get; set; }
        public string RandomString { get; set; }
        public string FrameRepeatString { get; set; }
        public List<FrameSequence> FrameSequences { get; set; }
        public int LoopCount { get; set; }
        public int FrameRepeat { get; set; }
        public int Random { get; set; }
    }

    public class Logic
    {
        public uint Credits { get; set; }
        public Action Action { get; set; }
        public List<object> CustomVars { get; set; }
        public List<ParticleSystem> ParticleSystems { get; set; }
        public ParticleSystem ParticleSystem { get; set; }
        public Mask Mask { get; set; }
        public Model Model { get; set; }
    }

    public class Main
    {
        public RoomItemData RoomItemData { get; set; }
        public WallItemData WallItemData { get; set; }
        public PetItemData PetItemData { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class Mask
    {
        public string Type { get; set; }
    }

    public class MetaData
    {
        public Category Category { get; set; }
    }

    public class MGameObject
    {
        public int MFileId { get; set; }
        public int MPathId { get; set; }
    }

    public class Model
    {
        public Dimensions Dimensions { get; set; }
        public List<Direction> Directions { get; set; }
        public int Populated { get; set; }
        public List<int> DirectionIds { get; set; }
    }

    public class MScript
    {
        public int MFileId { get; set; }
        public long MPathId { get; set; }
    }

    public class Offset
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public class ParticleSystem
    {
        public int Size { get; set; }
        public int CanvasId { get; set; }
        public int OffsetY { get; set; }
        public int Blend { get; set; }
        public long BgColor { get; set; }
        public Emitter Emitter { get; set; }
    }

    public class ParticleSystem2
    {
        public int Size { get; set; }
        public int CanvasId { get; set; }
        public int OffsetY { get; set; }
        public int Blend { get; set; }
        public long BgColor { get; set; }
        public Emitter Emitter { get; set; }
    }

    public class PetItemData
    {
        public string RunTimeClass { get; set; }
        public Dimensions Dimensions { get; set; }
        public List<object> Directions { get; set; }
        public List<object> States { get; set; }
    }

    public class RoomItemData
    {
        public string RuntimeClass { get; set; }
        public Dimensions Dimensions { get; set; }
        public List<int> Directions { get; set; }
        public List<State> States { get; set; }
    }

    public class FurnitureModel
    {
        public MGameObject MGameObject { get; set; }
        public int MEnabled { get; set; }
        public MScript MScript { get; set; }
        public string MName { get; set; }
        public int IdHash { get; set; }
        public string Id { get; set; }
        public Main Main { get; set; }
        public Index Index { get; set; }
        public Logic Logic { get; set; }
        public Visualization Visualization { get; set; }
        public AsAssets AsAssets { get; set; }
    }

    public class Simulation
    {
        public int Force { get; set; }
        public int Direction { get; set; }
        public int Energy { get; set; }
        public string ExplosionShape { get; set; }
        public int Gravity { get; set; }
        public int AirFriction { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
    }

    public class Visualization
    {
        public string Type { get; set; }
        public List<Visualization> Visualizations { get; set; }
        public string TypeLower { get; set; }
        public DefaultVisualization DefaultVisualization { get; set; }
    }

    public class Visualization2
    {
        public int Size { get; set; }
        public int Angle { get; set; }
        public List<Direction> Directions { get; set; }
        public List<object> Colors { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Animation> Animations { get; set; }
        public int LayerCount { get; set; }
        public int DefaultDirPopulated { get; set; }
        public DefaultDirection DefaultDirection { get; set; }
        public int DirsPopulated { get; set; }
    }

    public class WallItemData
    {
        public string RuntimeClass { get; set; }
        public List<object> States { get; set; }
    }
}
