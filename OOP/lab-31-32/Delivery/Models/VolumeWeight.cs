namespace Delivery.Models
{
    public class VolumeWeight
    {
        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal VolumetricWeight
        {
            get
            {
                return Length * Width * Height / 4000m;
            }
        }

        public decimal ChargeableWeight
        {
            get
            {
                return Math.Max(Weight, VolumetricWeight);
            }
        }
    }
}
