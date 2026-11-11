namespace PostService.App;

/// <summary>
/// Реакція на недоступність сервера: діалог «Повторити / Скасувати» з повторенням операції.
/// Перехоплює лише HttpRequestException без статус-коду; решта винятків іде далі.
/// </summary>
internal static class ServerUnavailableDialog
{
    /// <summary>
    /// Виконує операцію, а якщо сервер недоступний — пропонує повторити її.
    /// </summary>
    /// <returns>true, якщо операцію виконано; false, якщо користувач натиснув «Скасувати».</returns>
    public static async Task<bool> RunWithRetryAsync(IWin32Window owner, Func<Task> operation)
    {
        while (true)
        {
            try
            {
                await operation();
                return true;
            }
            catch (HttpRequestException e) when (e.StatusCode is null)
            {
                var answer = MessageBox.Show(owner,
                    "Не вдалося з'єднатися із сервером.\nПеревірте, чи запущено PostService, і спробуйте ще раз.",
                    "Сервер недоступний",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Warning);

                if (answer != DialogResult.Retry)
                {
                    return false;
                }
            }
        }
    }
}
