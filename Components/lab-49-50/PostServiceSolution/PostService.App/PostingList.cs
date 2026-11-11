using PostService.CommonTypes;
using PostService.Dtos;

namespace PostService.App;

public partial class PostingList : Form
{
    private readonly PostingApiClient _apiClient = new();

    public PostingList()
    {
        InitializeComponent();
        gridPostings.AutoGenerateColumns = false;
    }

    private async void PostingList_Load(object? sender, EventArgs e)
    {
        await LoadPostingsAsync();
    }

    private async Task LoadPostingsAsync()
    {
        try
        {
            gridPostings.DataSource = await _apiClient.GetAllAsync();
        }
        catch (HttpRequestException exception)
        {
            ShowError(PostingApiClient.DescribeError(exception));
        }
    }

    private async void btnCreate_Click(object? sender, EventArgs e)
    {
        using var editForm = new PostingEditForm(_apiClient, postingId: null);

        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            await LoadPostingsAsync();
        }
    }

    private async void btnEdit_Click(object? sender, EventArgs e)
    {
        if (GetSelectedPosting() is not PostingGetDto selectedPosting)
        {
            MessageBox.Show("Виберіть відправлення, яке потрібно редагувати.", Text);
            return;
        }

        using var editForm = new PostingEditForm(_apiClient, selectedPosting.Id);

        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            await LoadPostingsAsync();
        }
    }

    private async void btnDelete_Click(object? sender, EventArgs e)
    {
        if (GetSelectedPosting() is not PostingGetDto selectedPosting)
        {
            MessageBox.Show("Виберіть відправлення, яке потрібно видалити.", Text);
            return;
        }

        var answer = MessageBox.Show(
            $"Видалити відправлення {selectedPosting.From} → {selectedPosting.To}?\nЦю дію не можна скасувати.",
            "Підтвердження видалення",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);

        if (answer != DialogResult.Yes)
        {
            return;
        }

        try
        {
            await _apiClient.DeleteAsync(selectedPosting.Id);
        }
        catch (HttpRequestException exception)
        {
            ShowError(PostingApiClient.DescribeError(exception));

            if (exception.StatusCode is null)
            {
                return;
            }
        }

        await LoadPostingsAsync();
    }

    private void gridPostings_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        var column = gridPostings.Columns[e.ColumnIndex];

        if (column == colDeliveryType && e.Value is DeliveryType deliveryType)
        {
            e.Value = DeliveryTypeText.ToText(deliveryType);
            e.FormattingApplied = true;
        }
        else if (column == colValue && e.Value is null)
        {
            e.Value = "—";
            e.FormattingApplied = true;
        }
    }

    private PostingGetDto? GetSelectedPosting()
    {
        return gridPostings.CurrentRow?.DataBoundItem as PostingGetDto;
    }

    private void ShowError(string message)
    {
        MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
