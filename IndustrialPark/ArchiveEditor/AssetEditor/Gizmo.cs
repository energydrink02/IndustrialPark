﻿using SharpDX;
using System;
using System.Collections.Generic;

namespace IndustrialPark
{
    public enum GizmoType
    {
        X,
        Y,
        Z,
    }

    public class Gizmo
    {
        public GizmoType type;
        public bool isSelected;
        private Matrix transformMatrix;

        public Gizmo(GizmoType type)
        {
            this.type = type;

            switch (type)
            {
                case GizmoType.X:
                    renderData.Color = new Vector4(1f, 0f, 0f, 0.4f);
                    break;
                case GizmoType.Y:
                    renderData.Color = new Vector4(0f, 1f, 0f, 0.4f);
                    break;
                case GizmoType.Z:
                    renderData.Color = new Vector4(0f, 0f, 1f, 0.4f);
                    break;
            }
            isSelected = false;
            SetPosition(Vector3.Zero, 0);
        }

        public void SetPosition(Vector3 Position, float distance)
        {
            if (distance < 1f) distance = 1f;
            switch (type)
            {
                case GizmoType.X:
                    Position.X += distance;
                    transformMatrix = Matrix.Scaling(distance / 2f) * Matrix.RotationY(MathUtil.Pi / 2) * Matrix.Translation(Position);
                    break;
                case GizmoType.Y:
                    Position.Y += distance;
                    transformMatrix = Matrix.Scaling(distance / 2f) * Matrix.RotationX(-MathUtil.Pi / 2) * Matrix.Translation(Position);
                    break;
                case GizmoType.Z:
                    Position.Z += distance;
                    transformMatrix = Matrix.Scaling(distance / 2f) * Matrix.Translation(Position);
                    break;
            }

            boundingBox = BoundingBox.FromPoints(SharpRenderer.pyramidVertices.ToArray());
            boundingBox.Maximum = (Vector3)Vector3.Transform(boundingBox.Maximum, transformMatrix);
            boundingBox.Minimum = (Vector3)Vector3.Transform(boundingBox.Minimum, transformMatrix);
        }

        private DefaultRenderData renderData;

        public void Draw(SharpRenderer renderer)
        {
            renderData.worldViewProjection = transformMatrix * renderer.viewProjection;

            renderer.device.SetFillModeSolid();
            renderer.device.SetCullModeNone();
            renderer.device.SetBlendStateAlphaBlend();
            renderer.device.ApplyRasterState();
            renderer.device.SetDepthStateNone();
            renderer.device.UpdateAllStates();

            renderer.device.UpdateData(renderer.basicBuffer, renderData);
            renderer.device.DeviceContext.VertexShader.SetConstantBuffer(0, renderer.basicBuffer);
            renderer.basicShader.Apply();

            SharpRenderer.Pyramid.Draw(renderer.device);

            renderer.device.SetDefaultDepthState();
        }

        public BoundingBox boundingBox;

        public float? IntersectsWith(Ray r)
        {
            if (r.Intersects(ref boundingBox, out float distance))
                if (TriangleIntersection(r))
                    return distance;

            return null;
        }

        public bool TriangleIntersection(Ray r)
        {
            List<Vector3> pyramidVertices = SharpRenderer.pyramidVertices;

            foreach (Models.Triangle t in SharpRenderer.pyramidTriangles)
            {
                Vector3 v1 = (Vector3)Vector3.Transform(pyramidVertices[t.vertex1], transformMatrix);
                Vector3 v2 = (Vector3)Vector3.Transform(pyramidVertices[t.vertex2], transformMatrix);
                Vector3 v3 = (Vector3)Vector3.Transform(pyramidVertices[t.vertex3], transformMatrix);

                if (r.Intersects(ref v1, ref v2, ref v3))
                    return true;
            }
            return false;
        }
    }
}