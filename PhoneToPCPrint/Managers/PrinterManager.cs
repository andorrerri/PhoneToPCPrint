using System;
using System.Diagnostics;
using System.IO;

public static class PrinterManager
{
    public static void Print(string file)
    {
        string ext = Path.GetExtension(file).ToLower();

        try
        {
            if (ext == ".pdf")
            {
                PrintWithSumatra(file);
            }
            else if (IsWord(ext))
            {
                PrintOffice("Word.Application", file);
            }
            else if (IsExcel(ext))
            {
                PrintOffice("Excel.Application", file);
            }
            else if (IsPowerPoint(ext))
            {
                PrintOffice("PowerPoint.Application", file);
            }
            else
            {
                PrintDefault(file);
            }
        }
        catch (Exception ex)
        {
            Logger.Info("Print error: " + ex.Message);
        }
    }

    private static void PrintWithSumatra(string file)
    {
        string exe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SumatraPDF.exe");

        Process.Start(new ProcessStartInfo
        {
            FileName = exe,
            Arguments = $"-print-to-default -silent \"{file}\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
    }

    private static void PrintDefault(string file)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = file,
            Verb = "print",
            UseShellExecute = true
        });
    }

    private static void PrintOffice(string app, string file)
    {
        dynamic office = Activator.CreateInstance(Type.GetTypeFromProgID(app));
        office.Visible = false;

        dynamic doc = office.Documents.Open(file, ReadOnly: true);
        doc.PrintOut();
        doc.Close(false);

        office.Quit();
    }

    private static bool IsWord(string ext) =>
        ext == ".doc" || ext == ".docx";

    private static bool IsExcel(string ext) =>
        ext == ".xls" || ext == ".xlsx";

    private static bool IsPowerPoint(string ext) =>
        ext == ".ppt" || ext == ".pptx";
}