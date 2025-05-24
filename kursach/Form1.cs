using System.Diagnostics;
using System.Windows.Forms;
using System;

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
                DialogResult result = MessageBox.Show("Вы хотите сохранить изменения перед выходом?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

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
        
            MatchCollection matches = regex.Matches(input, pattern);
        
            foreach (Match match in matches)
            {
                richTextBox2.Text += match.Value;
            }
        }
        
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            string pattern = @"^(?:[a-zA-Z]:\\|\\\\[^\\\/:*?""<>|\r\n]+\\[^\\\/:*?""<>|\r\n]+\\|\.{0,2}\\)?(?:[^\\\/:*?""<>|\r\n]+\\)*[^\\\/:*?""<>|\r\n]*$";
        
            Regex regex = new Regex(pattern);
        
            
            foreach (string path in input)
            {
                richTextBox2.Text += $"{path} – {(regex.IsMatch(path) ? "Valid" : "Invalid")}";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void пускToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}