using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Obi
{
    public class ObiBlueprintRenderModeDistanceConstraints : ObiBlueprintRenderMode
    {
        public override string name
        {
            get { return "Distance constraints"; }
        }

        public ObiBlueprintRenderModeDistanceConstraints(ObiActorBlueprintEditor editor) : base(editor)
        {
        }

        public override void OnSceneRepaint(SceneView sceneView)
        {

            using (new Handles.DrawingScope(Color.green, Matrix4x4.identity))
            {
                var constraints = editor.blueprint.GetConstraintsByType(Oni.ConstraintType.Distance) as ObiConstraints<ObiDistanceConstraintsBatch>;
                if (constraints != null)
                {
                    Vector3[] lines = new Vector3[constraints.GetActiveConstraintCount() * 2];
                    int lineIndex = 0;

                    foreach (var batch in constraints.batches)
                    {
                        for (int i = 0; i < batch.activeConstraintCount; ++i)
                        {
                            lines[lineIndex++] = editor.blueprint.GetParticlePosition(batch.particleIndices[i * 2]);
                            lines[lineIndex++] = editor.blueprint.GetParticlePosition(batch.particleIndices[i * 2 + 1]); 
                        }
                    }

                    Handles.DrawLines(lines);
                }
            } 
        }

    }
}