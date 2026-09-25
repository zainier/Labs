using System.Globalization;
using Delivery.Models;
using Delivery.Services;
using Delivery.Strategies;

namespace Delivery
{
    public partial class Form1 : Form
    {
        private readonly IDeliveryCostService _deliveryCostService;

        public Form1()
        {
            InitializeComponent();

            _deliveryCostService = new DeliveryCostService(new IDeliveryCostStrategy[]
            {
                new DepartmentDeliveryStrategy(),
                new CourierDeliveryStrategy(),
                new ExpressCourierDeliveryStrategy()
            });

            InitializeDeliveryOptions();
        }

        private void InitializeDeliveryOptions()
        {
            cmbDelivery.Items.Add(new DeliveryOption(DeliveryType.Department, "Доставка у відділення"));
            cmbDelivery.Items.Add(new DeliveryOption(DeliveryType.Courier, "Кур'єром додому"));
            cmbDelivery.Items.Add(new DeliveryOption(DeliveryType.ExpressCourier, "Експрес кур'єром додому"));
            cmbDelivery.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cmbDelivery.SelectedItem is not DeliveryOption option)
            {
                MessageBox.Show(
                    "Оберіть спосіб доставки.",
                    "Розрахунок вартості доставки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            VolumeWeight volumeWeight = new VolumeWeight
            {
                Weight = numWeight.Value,
                Length = numLength.Value,
                Width = numWidth.Value,
                Height = numHeight.Value
            };

            decimal price = _deliveryCostService.Calculate(volumeWeight, option.DeliveryType);

            lblActualValue.Text = FormatWeight(volumeWeight.Weight);
            lblVolumeValue.Text = FormatWeight(volumeWeight.VolumetricWeight);
            lblChargeValue.Text = FormatWeight(volumeWeight.ChargeableWeight);
            lblMethodValue.Text = option.Name;
            lblCostValue.Text = FormatPrice(price);

            lblStatus.Text = "Розрахунок виконано";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            numWeight.Value = 0m;
            numLength.Value = 0m;
            numWidth.Value = 0m;
            numHeight.Value = 0m;
            cmbDelivery.SelectedIndex = 0;

            lblActualValue.Text = "—";
            lblVolumeValue.Text = "—";
            lblChargeValue.Text = "—";
            lblMethodValue.Text = "—";
            lblCostValue.Text = "—";

            lblStatus.Text = "Готово до розрахунку";
        }

        private static string FormatWeight(decimal weight)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:0.0} кг", weight);
        }

        private static string FormatPrice(decimal price)
        {
            string number = price == Math.Truncate(price)
                ? price.ToString("0", CultureInfo.CurrentCulture)
                : price.ToString("0.00", CultureInfo.CurrentCulture);

            return number + " грн";
        }

        private sealed class DeliveryOption
        {
            public DeliveryOption(DeliveryType deliveryType, string name)
            {
                DeliveryType = deliveryType;
                Name = name;
            }

            public DeliveryType DeliveryType { get; }

            public string Name { get; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
