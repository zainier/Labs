using System.Diagnostics;
using System.Reflection;

namespace PostService.App;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventHandler;

        // Без цього WinForms сам перехоплює винятки потоку інтерфейсу й показує власне вікно,
        // і до глобального обробника UnhandledException вони не доходять.
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

        ApplicationConfiguration.Initialize();
        Application.Run(new PostingList());
    }

    private static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception;

        // Винятки з асинхронних обробників форми можуть надходити загорнутими.
        if (exception is TargetInvocationException { InnerException: not null } wrapped)
        {
            exception = wrapped.InnerException;
        }

        // Подробиці для розробника: час, тип, повідомлення, стек викликів (ToString містить і вкладені винятки).
        Debug.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Необроблений виняток {exception?.GetType().FullName}");
        Debug.WriteLine($"Повідомлення: {exception?.Message}");
        Debug.WriteLine(exception?.ToString());

        // Користувачу — лише зрозуміле повідомлення без технічних деталей.
        MessageBox.Show(
            "Сталася непередбачена помилка, і програму буде закрито.\nПодробиці записано для розробника.",
            "Помилка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
