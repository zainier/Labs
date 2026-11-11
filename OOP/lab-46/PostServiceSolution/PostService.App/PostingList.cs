using System.Net;
using PostService.CommonTypes;
using PostService.Dtos;

namespace PostService.App;

public partial class PostingList : Form
{
    private const string MissingPostingMessage = "Вибране відправлення вже відсутнє. Список буде оновлено.";

    private readonly IPostServiceClient _postService = new PostServiceClient();

    public PostingList()
    {
        InitializeComponent();
        gridPostings.AutoGenerateColumns = false;
    }

    private async void PostingList_Load(object? sender, EventArgs e)
    {
        await ReloadDataAndRefreshForm();
    }

    // Обробляється лише недоступність сервера (діалог повтору); інші помилки йдуть до глобального обробника.
    private async Task ReloadDataAndRefreshForm()
    {
        await ServerUnavailableDialog.RunWithRetryAsync(this, async () =>
        {
            gridPostings.DataSource = await _postService.GetPostingsAsync();
        });
    }

    private async void btnCreate_Click(object? sender, EventArgs e)
    {
        using var editForm = new PostingEditForm(_postService, postingId: null);

        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            await ReloadDataAndRefreshForm();
        }
    }

    private async void btnEdit_Click(object? sender, EventArgs e)
    {
        if (GetSelectedPosting() is not PostingGetDto selectedPosting)
        {
            MessageBox.Show("Виберіть відправлення, яке потрібно редагувати.", Text);
            return;
        }

        using var editForm = new PostingEditForm(_postService, selectedPosting.Id);
        var result = editForm.ShowDialog(this);

        // OK — зміни збережено; Abort — запис уже видалено на сервері (форма про це повідомила).
        if (result is DialogResult.OK or DialogResult.Abort)
        {
            await ReloadDataAndRefreshForm();
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

        SetButtonsEnabled(false);

        try
        {
            var deleted = await ServerUnavailableDialog.RunWithRetryAsync(this,
                () => _postService.DeletePostingAsync(selectedPosting.Id));

            if (deleted)
            {
                await ReloadDataAndRefreshForm();
            }
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            MessageBox.Show(MissingPostingMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            await ReloadDataAndRefreshForm();
        }
        finally
        {
            SetButtonsEnabled(true);
        }
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

    private void SetButtonsEnabled(bool enabled)
    {
        btnCreate.Enabled = btnEdit.Enabled = btnDelete.Enabled = enabled;
    }
}
