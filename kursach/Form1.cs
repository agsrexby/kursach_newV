using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Text.RegularExpressions;

namespace kursach
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
        private bool isTextChanged = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик для пункта "Создать"
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            currentFilePath = string.Empty;
            isTextChanged = false;
        }

        // Обработчик для пункта "Открыть"
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                isTextChanged = false;
            }
        }

        // Обработчик для пункта "Сохранить"
        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                // Если файл уже открыт, сохраняем изменения в него
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);
                isTextChanged = false;
            }
            else
            {
                // Если файл не открыт, вызываем диалог сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName; // Сохраняем путь к файлу
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);
                    isTextChanged = false;
                }
            }
        }

        // Обработчик для пункта "Сохранить как"
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);
                isTextChanged = false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        // Обработчик для пункта "Выход"
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("Вы хотите сохранить изменения перед выходом?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click_1(sender, e); // Сохраняем изменения
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Отменяем выход
                }
            }

            Application.Exit(); // Выход из программы
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void постановкаЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.Task;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void грамматикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.Grammar;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void классификацияГрамматикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.klasif_grammar;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void методАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.analiz;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void диагностикаИНейтрализацияОшибокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.diagnost;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void тестовыйПримерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.test;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void списокЛитературыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.litera;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void исходныйКодПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.listing;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Получаем PDF из ресурсов (как byte[])
                byte[] pdfBytes = Properties.Resources.manual;

                // 2. Сохраняем во временный файл
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp_document.pdf");
                File.WriteAllBytes(tempPdfPath, pdfBytes);

                // 3. Запускаем программу для просмотра PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true // Открыть через ассоциированную программу
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Это приложение является курсовой работой Попова Алексея Романовича, студента группы АВТ-214.",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            currentFilePath = string.Empty;
            isTextChanged = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                isTextChanged = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                // Если файл уже открыт, сохраняем изменения в него
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);
                isTextChanged = false;
            }
            else
            {
                // Если файл не открыт, вызываем диалог сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName; // Сохраняем путь к файлу
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);
                    isTextChanged = false;
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            Lexer lexer = new(input);
            var tokens = lexer.Tokenize();

            Parser parser = new(tokens);
            var errors = parser.Parse();

            richTextBox2.Text = errors.Count == 0
                ? "Ошибок не обнаружено"
                : string.Join(Environment.NewLine, errors);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Manual.pdf");
            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Файл справки не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Это приложение является курсовой работой Попова Алексея Романовича, студента группы АВТ-214.",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            string pattern = @"<!--.*?-->";
            Regex regex = new Regex(pattern, RegexOptions.Singleline); // Singleline - чтобы . захватывал \n

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                richTextBox2.Text += match.Value;
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            string pattern = @"\b(20(1[0-9]|2[0-4]))\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                richTextBox2.Text += match.Value + " ";
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            string[] paths =
            {
                "C:\\Windows\\System32\\cmd.exe",
                "\\\\Server\\Share\\file.txt",
                "Folder\\Subfolder\\document.docx",
                ".\\config.json",
                "..\\archive.zip",
                "invalid|file.txt" // Невалидный путь
            };
            richTextBox1.Text = "C:\\Windows\\System32\\cmd.exe" + "\\\\Server\\Share\\file.txt" +
                                "Folder\\Subfolder\\document.docx" +
                                ".\\config.json" +
                                "..\\archive.zip" +
                                "invalid|file.txt";
            string pattern =
                @"^(?:[a-zA-Z]:\\|\\\\[^\\\/:*?""<>|\r\n]+\\[^\\\/:*?""<>|\r\n]+\\|\.{0,2}\\)?(?:[^\\\/:*?""<>|\r\n]+\\)*[^\\\/:*?""<>|\r\n]*$";

            Regex regex = new Regex(pattern);

            // Разбиваем текст на отдельные строки для проверки
            foreach (string path in paths)
            {
                richTextBox2.Text += $"{path} – {(regex.IsMatch(path) ? "Valid" : "Invalid")}\n";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        // {
        //     string input = richTextBox1.Text;
        //     Lexer lexer = new(input);
        //     var tokens = lexer.Tokenize();
        //
        //     Parser parser = new(tokens);
        //     var errors = parser.Parse();
        //
        //     richTextBox2.Text = errors.Count == 0
        //         ? "Ошибок не обнаружено"
        //         : string.Join(Environment.NewLine, errors);
        // }

        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string program = richTextBox1.Text;
                richTextBox2.Clear();

                var parser = new FalseParser(program);
                parser.SetOutput(richTextBox2);

                richTextBox2.AppendText("Начало анализа программы...\n");
                parser.ParseProgram();

                if (parser.HasErrors)
                {
                    richTextBox2.AppendText("\nАнализ завершен с ошибками.");
                }
                else
                {
                    richTextBox2.AppendText("\nАнализ завершен успешно. Ошибок не обнаружено.");
                }
            }
            catch (Exception ex)
            {
                richTextBox2.Text = $"Ошибка при анализе: {ex.Message}";
            }
        }

        public class FalseParser
        {
            private string input;
            private int pos;
            private RichTextBox output;
            public bool HasErrors { get; private set; }

            public FalseParser(string program)
            {
                this.input = program;
                this.pos = 0;
                this.HasErrors = false;
            }

            public void SetOutput(RichTextBox outputBox)
            {
                this.output = outputBox;
            }

            private void Error(string message)
            {
                HasErrors = true;
                output.AppendText($"Ошибка в позиции {pos}: {message}\n");
            }

            private char Peek()
            {
                return pos < input.Length ? input[pos] : '\0';
            }

            private void Match(char expected)
            {
                if (Peek() == expected)
                {
                    pos++;
                }
                else
                {
                    Error($"Ожидался символ '{expected}'");
                }
            }

            public void ParseProgram()
            {
                while (Peek() != '\0' && !HasErrors)
                {
                    ParseInstr();
                }
            }

            private void ParseInstr()
            {
                char current = Peek();
                switch (current)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '_':
                    case '=':
                    case '>':
                    case '&':
                    case '|':
                    case '~':
                    case '$':
                    case '%':
                    case '\\':
                    case '@':
                        output.AppendText($"Найдена инструкция: {current}\n");
                        pos++;
                        break;
                    case '[':
                        output.AppendText("Начало цикла [\n");
                        pos++; // Пропускаем '['

                        // Сохраняем текущую позицию для проверки прогресса
                        int lastPos = -1;
                        while (Peek() != ']' && !HasErrors)
                        {
                            // Защита от бесконечного цикла
                            if (pos == lastPos)
                            {
                                Error("Нет прогресса при разборе цикла");
                                break;
                            }

                            lastPos = pos;

                            ParseInstr();
                        }

                        Match(']'); // Проверяем закрывающую ']'
                        output.AppendText("Конец цикла ]\n");
                        break;
                    case ']':
                        // Выходим из рекурсии при встрече ']'
                        return;
                    default:
                        Error($"Неизвестная инструкция '{current}'");
                        pos++; // Продолжаем анализ после ошибки
                        break;
                }
            }
        }
    }
}