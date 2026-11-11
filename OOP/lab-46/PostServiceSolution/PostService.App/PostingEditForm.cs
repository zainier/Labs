using System.Globalization;
using System.Net;
using PostService.CommonTypes;
using PostService.Dtos;

namespace PostService.App;

/// <summary>
/// Спільне діалогове вікно створення (postingId = null) та редагування відправлення.
/// DialogResult.OK — зміни збережено; DialogResult.Abort — запис уже відсутній на сервері.
/// </summary>
internal partial class PostingEditForm : Form
{
    private static readonly Color ErrorBackColor = Color.FromArgb(254, 242, 242);

    private readonly IPostServiceClient _postService;
    private readonly int? _postingId;
    private readonly Dictionary<string, (Control Control, Label ErrorLabel)> _fields;
    private PostingGetDto? _loadedPosting;

    public PostingEditForm(IPostServiceClient postService, int? postingId)
    {
        InitializeComponent();

        _postService = postService;
        _postingId = postingId;

        foreach (var deliveryType in Enum.GetValues<DeliveryType>())
        {
            cmbDeliveryType.Items.Add(new DeliveryTypeOption(deliveryType));
        }

        // Ключі збігаються з назвами полів, якими сервер позначає помилки валідації.
        _fields = new(StringComparer.OrdinalIgnoreCase)
        {
            ["from"] = (txtFrom, lblFromError),
            ["to"] = (txtTo, lblToError),
            ["content"] = (txtContent, lblContentError),
            ["deliveryType"] = (cmbDeliveryType, lblDeliveryTypeError),
            ["weight"] = (txtWeight, lblWeightError),
            ["value"] = (txtValue, lblValueError),
            ["width"] = (txtWidth, lblWidthError),
            ["height"] = (txtHeight, lblHeightError),
            ["depth"] = (txtDepth, lblDepthError)
        };

        foreach (var (control, _) in _fields.Values)
        {
            errorProvider.SetIconPadding(control, 6);
        }

        Text = postingId is null ? "Нове відправлення" : "Редагування відправлення";
        lblHeading.Text = Text;
    }

    private async void PostingEditForm_Load(object? sender, EventArgs e)
    {
        if (_postingId is not int postingId)
        {
            txtPrice.Text = "—";
            return;
        }

        btnSave.Enabled = false;

        try
        {
            var loaded = await ServerUnavailableDialog.RunWithRetryAsync(this, async () =>
            {
                _loadedPosting = await _postService.GetPostingByIdAsync(postingId);
            });

            if (!loaded)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            FillFields(_loadedPosting!);
            btnSave.Enabled = true;
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            ReportMissingPostingAndClose();
        }
    }

    private async void btnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput())
        {
            return;
        }

        btnSave.Enabled = btnCancel.Enabled = false;

        try
        {
            var saved = await ServerUnavailableDialog.RunWithRetryAsync(this, async () =>
            {
                if (_loadedPosting is null)
                {
                    await _postService.CreatePostingAsync(BuildPostDto());
                }
                else
                {
                    await _postService.UpdatePostingAsync(_loadedPosting.Id, BuildPutDto(_loadedPosting));
                }
            });

            if (saved)
            {
                DialogResult = DialogResult.OK;
            }
        }
        catch (PostingValidationException ex)
        {
            ShowServerErrors(ex.Errors);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound && _loadedPosting is not null)
        {
            ReportMissingPostingAndClose();
        }
        finally
        {
            btnSave.Enabled = btnCancel.Enabled = true;
        }
    }

    private void ReportMissingPostingAndClose()
    {
        MessageBox.Show(this, "Відправлення вже відсутнє на сервері. Список буде оновлено.",
            Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        DialogResult = DialogResult.Abort;
    }

    /// <summary>Помилки сервера показуються біля відповідних полів; невідомі поля — окремим повідомленням.</summary>
    private void ShowServerErrors(Dictionary<string, string[]> errors)
    {
        var otherMessages = new List<string>();

        foreach (var (field, messages) in errors)
        {
            if (_fields.TryGetValue(field, out var target))
            {
                SetFieldError(target.Control, target.ErrorLabel, string.Join(" ", messages));
            }
            else
            {
                otherMessages.AddRange(messages);
            }
        }

        if (otherMessages.Count > 0)
        {
            MessageBox.Show(this, string.Join(Environment.NewLine, otherMessages),
                "Перевірте введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void FillFields(PostingGetDto posting)
    {
        txtFrom.Text = posting.From;
        txtTo.Text = posting.To;
        txtContent.Text = posting.Content;
        cmbDeliveryType.SelectedItem = cmbDeliveryType.Items
            .Cast<DeliveryTypeOption>()
            .First(option => option.Value == posting.DeliveryType);
        txtWeight.Text = FormatNumber(posting.Weight);
        txtValue.Text = posting.Value is float value ? FormatNumber(value) : string.Empty;
        txtWidth.Text = FormatNumber(posting.Width);
        txtHeight.Text = FormatNumber(posting.Height);
        txtDepth.Text = FormatNumber(posting.Depth);
        txtPrice.Text = FormatNumber(posting.Price);
    }

    private bool ValidateInput()
    {
        var isValid = true;

        isValid &= CheckRequiredText(txtFrom, lblFromError, "Вкажіть відправника");
        isValid &= CheckRequiredText(txtTo, lblToError, "Вкажіть отримувача");
        isValid &= CheckRequiredText(txtContent, lblContentError, "Вкажіть вміст відправлення");
        isValid &= SetFieldError(cmbDeliveryType, lblDeliveryTypeError,
            cmbDeliveryType.SelectedItem is null ? "Виберіть тип доставки" : null);
        isValid &= CheckPositiveNumber(txtWeight, lblWeightError, "Введіть вагу числом, більшим за 0");
        isValid &= CheckOptionalNumber(txtValue, lblValueError, "Введіть цінність числом, не меншим за 0");
        isValid &= CheckPositiveNumber(txtWidth, lblWidthError, "Введіть ширину числом, більшим за 0");
        isValid &= CheckPositiveNumber(txtHeight, lblHeightError, "Введіть висоту числом, більшим за 0");
        isValid &= CheckPositiveNumber(txtDepth, lblDepthError, "Введіть глибину числом, більшим за 0");

        return isValid;
    }

    private bool CheckRequiredText(TextBox textBox, Label errorLabel, string message)
    {
        return SetFieldError(textBox, errorLabel,
            string.IsNullOrWhiteSpace(textBox.Text) ? message : null);
    }

    private bool CheckPositiveNumber(TextBox textBox, Label errorLabel, string message)
    {
        var isCorrect = TryParseNumber(textBox.Text, out var number) && number > 0;

        return SetFieldError(textBox, errorLabel, isCorrect ? null : message);
    }

    private bool CheckOptionalNumber(TextBox textBox, Label errorLabel, string message)
    {
        var isCorrect = string.IsNullOrWhiteSpace(textBox.Text)
            || (TryParseNumber(textBox.Text, out var number) && number >= 0);

        return SetFieldError(textBox, errorLabel, isCorrect ? null : message);
    }

    private bool SetFieldError(Control control, Label errorLabel, string? message)
    {
        errorProvider.SetError(control, message ?? string.Empty);
        errorLabel.Text = message ?? string.Empty;

        if (control is TextBox)
        {
            control.BackColor = message is null ? SystemColors.Window : ErrorBackColor;
        }

        return message is null;
    }

    private PostingPostDto BuildPostDto()
    {
        return new PostingPostDto
        {
            From = txtFrom.Text.Trim(),
            To = txtTo.Text.Trim(),
            Content = txtContent.Text.Trim(),
            DeliveryType = SelectedDeliveryType,
            Weight = ParseNumber(txtWeight.Text),
            Width = ParseNumber(txtWidth.Text),
            Height = ParseNumber(txtHeight.Text),
            Depth = ParseNumber(txtDepth.Text),
            Value = ParseOptionalNumber(txtValue.Text)
        };
    }

    private PostingPutDto BuildPutDto(PostingGetDto original)
    {
        return new PostingPutDto
        {
            Id = original.Id,
            From = txtFrom.Text.Trim(),
            To = txtTo.Text.Trim(),
            Content = txtContent.Text.Trim(),
            DeliveryType = SelectedDeliveryType,
            Weight = ParseNumber(txtWeight.Text),
            Width = ParseNumber(txtWidth.Text),
            Height = ParseNumber(txtHeight.Text),
            Depth = ParseNumber(txtDepth.Text),
            Value = ParseOptionalNumber(txtValue.Text),
            Price = original.Price,
            Description = original.Description
        };
    }

    private DeliveryType SelectedDeliveryType =>
        ((DeliveryTypeOption)cmbDeliveryType.SelectedItem!).Value;

    private static bool TryParseNumber(string text, out float number)
    {
        text = text.Trim();

        var isParsed = float.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out number)
            || float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out number);

        return isParsed && float.IsFinite(number);
    }

    private static float ParseNumber(string text)
    {
        TryParseNumber(text, out var number);
        return number;
    }

    private static float? ParseOptionalNumber(string text)
    {
        return string.IsNullOrWhiteSpace(text) ? null : ParseNumber(text);
    }

    private static string FormatNumber(float number)
    {
        return number.ToString(CultureInfo.CurrentCulture);
    }

    private sealed record DeliveryTypeOption(DeliveryType Value)
    {
        public override string ToString() => DeliveryTypeText.ToText(Value);
    }
}
