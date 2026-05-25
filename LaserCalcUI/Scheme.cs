namespace LaserCalcUI
{
    /// <summary>
    /// Stores armor layers and calculates pen requirements
    /// </summary>
    /// <param name="layerList">List of armor layers to be penetrated with each shot</param>
    public class Scheme(List<Layer> layerList)
    {
        public List<Layer> LayerList { get; } = layerList;

        /// <summary>
        /// Calculate applied damage to penetrate entire armor scheme with one shot
        /// </summary>
        /// <param name="appliedIntensity">Laser intensity after smoke and shield reductions</param>
        /// <returns></returns>
        public float CalculateRequiredDamageToPen(float appliedIntensity)
        {
            if (appliedIntensity <= 0f) return float.PositiveInfinity;
            float requiredDamage = 0f;

            for (int layerIndex = 0; layerIndex < LayerList.Count; layerIndex++)
            {
                Layer currentLayer = LayerList[layerIndex];
                requiredDamage += currentLayer.HP * MathF.Max(1f, currentLayer.FireResistance / appliedIntensity);
            }
            return requiredDamage;
        }
    }
}
