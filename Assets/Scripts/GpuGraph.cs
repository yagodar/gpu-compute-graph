using UnityEngine;

public class GpuGraph : MonoBehaviour
{
    private static readonly int PositionsId = Shader.PropertyToID("positions");
    private static readonly int ResolutionId = Shader.PropertyToID("resolution");
    private static readonly int StepSizeId = Shader.PropertyToID("step_size");

    [SerializeField]
    ComputeShader computeShader;

    [SerializeField]
    [Range(1000, 100000)]
    private int resolution = 1000;

    private ComputeBuffer _positionsBuffer;

    private void OnEnable()
    {
        _positionsBuffer = new ComputeBuffer(resolution * resolution, 2 * sizeof(float));
    }

    private void OnDisable()
    {
        _positionsBuffer.Release();
        _positionsBuffer = null;
    }
    
    private void UpdateFunctionOnGPU () {
        computeShader.SetInt(ResolutionId, resolution);
        computeShader.SetFloat(StepSizeId, 2f / resolution);
    }
}
