namespace SoldHelper
{
    using System.Globalization;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        List<ProductSale> sales = new();
        private int selectedIndex = -1;
        private Dictionary<string, string> productNames = new();
        // private System.Windows.Forms.CheckBox checkEditEndDate;
        private System.Windows.Forms.CheckBox checkCustomEndDate;
        public Form1()
        {
            InitializeComponent();
            dateStart.MinDate = DateTime.Today.AddDays(14);
            dateStart.ValueChanged += (s, e) =>
            {
                dateEnd.Value = dateStart.Value.AddDays(14);
            };

            percentBox.Text = "50";
            LoadProductNames();

        }
        private void LoadProductNames()
        {
            string path = "Product.txt";
            if (!File.Exists(path)) return;

            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split(':', 2);
                if (parts.Length != 2) continue;
                string name = parts[0].Trim();
                string url = parts[1].Trim();
                if (!productNames.ContainsKey(url))
                {
                    productNames.Add(url, name);
                }
            }
        }
        private void checkCustomEndDate_CheckedChanged(object sender, EventArgs e)
        {
            dateEnd.Enabled = checkCustomEndDate.Checked;

            if (checkCustomEndDate.Checked)
            {
                // Limite la date de fin à max 14 jours après la date de début
                dateEnd.MinDate = dateStart.Value;
                dateEnd.MaxDate = dateStart.Value.AddDays(14);
            }
            else
            {
                // Réinitialise automatiquement dateEnd
                dateEnd.Value = dateStart.Value.AddDays(14);
            }
        }
        private HashSet<int> linesToHighlight = new();

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if (!checkCustomEndDate.Checked)
            {
                dateEnd.Value = dateStart.Value.AddDays(14);
            }
            else
            {
                dateEnd.MinDate = dateStart.Value;
                dateEnd.MaxDate = dateStart.Value.AddDays(14);
                if (dateEnd.Value > dateEnd.MaxDate)
                    dateEnd.Value = dateEnd.MaxDate;
            }
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= listBox.Items.Count) return;

            string itemText = listBox.Items[e.Index].ToString();
            Brush brush = linesToHighlight.Contains(e.Index) ? Brushes.Red : Brushes.Black;

            e.DrawBackground();
            e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void btnCheckPeriod_Click(object sender, EventArgs e)
        {
            DateTime checkStart = checkStartDate.Value.Date;
            DateTime checkEnd = checkEndDate.Value.Date;

            if (checkExtend30.Checked)
                checkEnd = checkEnd.AddDays(30);

            linesToHighlight.Clear();

            for (int i = 0; i < sales.Count; i++)
            {
                var sale = sales[i];

                // Vérifie si les périodes se chevauchent
                if (sale.StartDate <= checkEnd && sale.EndDate >= checkStart)
                {
                    linesToHighlight.Add(i);
                }
            }

            listBox.Invalidate(); // Redessine la ListBox avec couleurs
        }
        private void btnNextRotation_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0 || selectedIndex >= sales.Count) return;

            var current = sales[selectedIndex];
            DateTime newStart = current.EndDate.AddDays(31);
            DateTime newEnd = newStart.AddDays(14);

            // Vérification : date actuelle vs nouvelle date de début
            TimeSpan difference = newStart - DateTime.Now.Date;
            if (difference.TotalDays >= 60)
            {
                MessageBox.Show("The next rotation is too far from the current date (60 days or more).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            current.StartDate = newStart;
            current.EndDate = newEnd;
            sales[selectedIndex] = current;

            // Mise à jour UI
            dateStart.Value = newStart;
            dateEnd.Value = newEnd;

            RefreshList();
            listBox.SelectedIndex = selectedIndex;
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                selectedIndex = listBox.SelectedIndex;
                var item = sales[selectedIndex];

                urlBox.Text = item.Url;
                dateStart.Value = item.StartDate;
                dateEnd.Value = item.EndDate;
                percentBox.Text = item.PercentageOff.ToString();

                // Remplir le champ nom si connu
                nameBox.Text = productNames.ContainsKey(item.Url) ? productNames[item.Url] : "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(percentBox.Text, out int percent)) percent = 50;

            var sale = new ProductSale
            {
                Url = urlBox.Text,
                StartDate = dateStart.Value,
                EndDate = dateEnd.Value,
                PercentageOff = percent
            };

            sales.Add(sale);
            productNames[sale.Url] = nameBox.Text;

            SaveProductNames();
            RefreshList();
        }

        private void RefreshList()
        {
            listBox.Items.Clear();
            for (int i = 0; i < sales.Count; i++)
            {
                var s = sales[i];
                string productName = productNames.ContainsKey(s.Url) ? productNames[s.Url] : "(Inconnu)";
                listBox.Items.Add($"{s.Url}\t{s.StartDate:MM/dd/yyyy}\t{s.EndDate:MM/dd/yyyy}\t{s.PercentageOff}\t{productName}");
            }

            listBox.Invalidate(); // Nécessaire si on utilise le dessin custom (pour le rouge)
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                sales.RemoveAt(listBox.SelectedIndex);
                RefreshList();

            }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers texte (*.txt)|*.txt";
            saveFileDialog.Title = "Exporter les soldes";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string soldePath = saveFileDialog.FileName;
                string productPath = Path.Combine(Path.GetDirectoryName(soldePath), "Product.txt");

                using StreamWriter sw = new StreamWriter(soldePath);
                foreach (var s in sales)
                {
                    sw.WriteLine($"{s.Url}\t{s.StartDate:MM/dd/yyyy}\t{s.EndDate:MM/dd/yyyy}\t{s.PercentageOff}");
                }

                using StreamWriter pw = new StreamWriter(productPath);
                foreach (var s in sales)
                {
                    if (productNames.TryGetValue(s.Url, out var name))
                    {
                        pw.WriteLine($"{name} : {s.Url}");
                    }
                }
            }
        }
        private void SaveProductNames()
        {
            const string path = "Product.txt";
            using StreamWriter sw = new StreamWriter(path);
            foreach (var sale in sales)
            {
                if (productNames.TryGetValue(sale.Url, out var name))
                {
                    sw.WriteLine($"{name} : {sale.Url}");
                }
            }
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers texte (*.txt)|*.txt";
            openFileDialog.Title = "Importer un fichier de soldes";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sales.Clear();
                foreach (var line in File.ReadAllLines(openFileDialog.FileName))
                {
                    var parts = line.Split('\t');
                    if (parts.Length != 4) continue;
                    sales.Add(new ProductSale
                    {
                        Url = parts[0],
                        StartDate = DateTime.ParseExact(parts[1], "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        EndDate = DateTime.ParseExact(parts[2], "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        PercentageOff = int.Parse(parts[3])
                    });
                }
                RefreshList();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0 || selectedIndex >= sales.Count) return;

            if (!int.TryParse(percentBox.Text, out int percent)) percent = 50;

            sales[selectedIndex] = new ProductSale
            {
                Url = urlBox.Text,
                StartDate = dateStart.Value,
                EndDate = dateStart.Value.AddDays(14),
                PercentageOff = percent
            };
            productNames[sales[selectedIndex].Url] = nameBox.Text;
            SaveProductNames();
            RefreshList();
            listBox.SelectedIndex = selectedIndex; // Garde la sélection visible
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void linkSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://support.fab.com/s/?ProductOrigin=FabSupport",
                UseShellExecute = true
            });
        }
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            var sb = new System.Text.StringBuilder();

            foreach (var s in sales)
            {
                sb.AppendLine($"{s.Url}\t{s.StartDate:MM/dd/yyyy}\t{s.EndDate:MM/dd/yyyy}\t{s.PercentageOff}");
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Les données ont été copiées dans le presse-papier.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void checkExtend30_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

    public class ProductSale
    {
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PercentageOff { get; set; }
    }
}
