namespace Models
{
    public class Posting : Model
    {
        public string TrackNumber { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string SenderAddress { get; set; } = string.Empty;
        public string ReceiverAddress { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Posting #{Id}: трек {TrackNumber}, вага {Weight} кг, "
                + $"від \"{SenderAddress}\" до \"{ReceiverAddress}\", статус: {DeliveryStatus}";
        }
    }
}
