using System;
using System.Collections.Generic;
using Trinity;
using Trinity.Core.Lib;
using Trinity.Network;

namespace MultiLayerServer
{
    /// <summary>
    /// Provides an interface for interacting with the MultiLayerGraph
    /// </summary>
    class Graph {



        public static int LayerCount {
            get {
                return Layers.Count;
            }
        }

        public static List<Layer> Layers {
            get;
            set;
        }

        public static void Init() {
            Layers = new List<Layer>();
        }

        public static void SaveNode(Node node) {
            Global.CloudStorage.SaveNode(node);
        }

        public static void AddEdges(long cellId, List<Edge> edges) {
            Node node = Graph.LoadNode(cellId);
            node.Edges.AddRange(edges);
            Graph.SaveNode(node);
        }

        public static void AddEdges(long nodeId, int nodeLayer, List<Edge> edges) {
            long cellId = Util.GetCellId(nodeId, nodeLayer);
            Graph.AddEdges(cellId, edges);
        }

        public static Node LoadNode(long cellId) {
            return Global.CloudStorage.LoadNode(cellId);
        }

        public static Node LoadNode(long nodeId, int nodeLayer) {
            long cellId = Util.GetCellId(nodeId, nodeLayer);
            return Graph.LoadNode(cellId);
        }


        public static bool HasNode(long cellId) {
            return Global.CloudStorage.Contains(cellId);
        }

        public static bool HasNode(long nodeId, int nodeLayer) {
            long cellId = Util.GetCellId(nodeId, nodeLayer);
            return Graph.HasNode(cellId);
        }

        public static void SaveToGEStorage() {
            Global.CloudStorage.SaveStorage();
        }

        public static void LoadFromGEStorage() {
            Global.CloudStorage.LoadStorage();
        }

    }
}
